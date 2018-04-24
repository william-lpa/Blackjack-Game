using Jogo21TrabalhoDeRedes.Conexao;
using Jogo21TrabalhoDeRedes.Jogo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo21TrabalhoDeRedes
{
    public partial class Form1 : Form
    {
        //Singletons
        TCPIP tcip = TCPIP.Instance;
        UDP udp = UDP.Instance;
        //Manter Thread para abortar o KeepAlive quando pedir para sair do jogo
        Thread keepAlive;
        
        /// <summary>
        /// Construtor. Desabilita alguns botões antes de se conectar ao servidor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            btRequestCard.Enabled = false;
            btSendMessage.Enabled = false;
            btStopTurn.Enabled = false;
            tbMessage.Enabled = false;
            comboBox1.Enabled = false;
        }
        
        /// <summary>
        /// Método para Habilitar/Desabilitar componente conforme situação do jogo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="components"></param>
       private void InvokeComponentEnableAction( bool value, params Control[] components )
       {
            foreach (var component in components)
            {
                this.Invoke(new Action(() =>component.Enabled = value));
            }
       }

        /// <summary>
        /// Monitora a conexão com o servidor a cada 6 segundos. Roda em uma thread paralela a principal para fazer a verificação. Se coenectado, habilita mensagens,
        /// preenche grid de usuários e jogadores, o label do status do jogador logado, o campo de eventos pra ver se tem novas mensagens.
        /// Se contiver vencedor no campo de eventos, reseta a mão de cartas e o texto de eventos
        /// Se perder conexão com o servidor, limpa os campos e desabilita botões.
        /// </summary>
        public void KeepAlive()
        {
            
            while (btStartQuitGame.Text == "Sair")
            {
                Movements monitore = new Movements();
                if (monitore.KeepAlive())
                {
                    this.Invoke(new Action(() => FillDataGrid(monitore.Users,monitore.GetPlayers())));
                    UpdatePlayerStatus();
                    InvokeComponentEnableAction(true,btSendMessage,tbMessage,comboBox1);
                    this.Invoke(new Action(() => {
                        if (tbEvents.Text.Contains("vencedor"))
                        {
                            Movements.Cards.Clear();
                            tbEvents.Text = "";
                        }
                    }));
                    this.Invoke(new Action(() => tbEvents.AppendText(monitore.getOldestMessage())));
                   

                }
                else
                {
                    btStartQuitGame.Text = "Jogar";
                    tbCards.Text = string.Empty;
                    tbEvents.Text = string.Empty;
                    tbScore.Text = string.Empty;
                    tbMessage.Text = string.Empty;
                    btRequestCard.Enabled = false;
                    btSendMessage.Enabled = false;
                    comboBox1.Enabled = false;
                    btStopTurn.Enabled = false;
                    tbMessage.Enabled = false;
                    ClearDataGrids();
                    MessageBox.Show(this,"Conexão com servidor Perdida","Conexão Perdida",MessageBoxButtons.OK,MessageBoxIcon.Error);    
                }
            }

        }

        /// <summary>
        /// Atualiza o label do usuários logado informando seu status. Habilita ou desabilita botões conforme status do jogo.
        /// </summary>
        private void UpdatePlayerStatus()
        {
            this.Invoke( new Action(() => this.labelStatus.Text = Movements.CurrentStatus.ToString()));

            if (Movements.CurrentStatus.Equals(Status.GETTING))
            {
                InvokeComponentEnableAction(true, btRequestCard, btStopTurn);
                
            }
            else
            {
                InvokeComponentEnableAction(false, btRequestCard, btStopTurn);
            }
        }

        /// <summary>
        /// Preenche datagrid com os usuários conectados e vitórias. Preenche datagrid com jogadores e seus status.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="players"></param>
        private void FillDataGrid(string[] users, string[] players)
        {

            ClearDataGrids();
            dataGridConnUsers.ColumnCount = 3;
            dataGridConnUsers.Columns[0].HeaderText = "ID";
            dataGridConnUsers.Columns[1].HeaderText = "Nome";
            dataGridConnUsers.Columns[2].HeaderText = "Vitórias";
            foreach (var user in users)
            {
                string[] currentUser = user.Split('-');
                var row = new string[] { currentUser[0], currentUser[1], currentUser[2] };
                dataGridConnUsers.Rows.Add(row);
            }

            dataGridPlayingUsers.ColumnCount = 2;
            dataGridPlayingUsers.Columns[0].HeaderText = "ID";
            dataGridPlayingUsers.Columns[1].HeaderText = "Status";            
            foreach (var player in players)
            {
                string[] currentPlayer = player.Split('-');
                var row = new string[] { currentPlayer[0], currentPlayer[1]};
                dataGridPlayingUsers.Rows.Add(row);
            }

            FillComboBox(users);

        }

        /// <summary>
        /// Preenche o combobox com os usuários conectados dispostos a receber minha mensagem. Chamado a cada 6 seg
        /// </summary>
        /// <param name="users"></param>
        private void FillComboBox(string[] users)
        {
            foreach (var item in users)
            {
                var user = item.Split('-')[0];
                if (!comboBox1.Items.Contains(user))
                comboBox1.Items.Add(user);
            }
        }

        /// <summary>
        /// limpa os grids de usuários e jogadores
        /// </summary>
        private void ClearDataGrids()
        {
            dataGridConnUsers.Columns.Clear();
            dataGridPlayingUsers.Columns.Clear();
        }

        /// <summary>
        /// Método do botão iniciar/parar de jogar. Faz as conexões com os protcolos UDP E TCP, validações  de interface e solicita pra jogar/sair.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btStartQuitGame_Click(object sender, EventArgs e)
        {

            Movements Game = new Movements();

            if (btStartQuitGame.Text == "Jogar")
            {
               tcip.UserID = tbUser.Text;
                tcip.Password = tbPassword.Text;
                tcip.Server = "larc.inf.furb.br";
                udp.Server = "larc.inf.furb.br";
                udp.UserID = tbUser.Text;
                udp.Password = tbPassword.Text;

                btStartQuitGame.Text = "Sair";
                keepAlive = new Thread(new ThreadStart(() => KeepAlive()));
                keepAlive.Start();
                Thread t = new Thread(new ThreadStart(() => StartGame()));
                t.Start();
                
            }
            else
            {
                Game.QuitGame();
                btStartQuitGame.Text = "Jogar";
                keepAlive?.Abort();
                ClearDataGrids();
            }
        }


        /// <summary>
        /// Espera 7 segundos para o servidor reconhecer meu usuario e peço pra jogar
        /// </summary>
        private void StartGame()
        {
            Movements Game = new Movements();
            Thread.Sleep(7000);
            Game.JoinGame();
        }

        /// <summary>
        /// Botão solictar Carta. Solicita uma nova carta, atualiza minha mao na interface e a minha soma de pontos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void btRequestCard_Click(object sender, EventArgs e)
        {
            try
            {
                Movements getCard = new Movements();
                getCard.GetNextCard();
                this.tbCards.Text = getCard.ShowTableCards();
                this.tbScore.Text = getCard.CurrentSum().ToString();
            }
            catch (Exception err)
            {
                tbEvents.AppendText(err.Message);
                
            }
        }

        /// <summary>
        /// Botão passa a vez. Diz que não quer mais carta e passa a vez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btStopTurn_Click(object sender, EventArgs e)
        {
            Movements stop = new Movements();

            stop.StopGettingCardTurn();
        }

        /// <summary>
        /// Botão Enviar Mensagem. Se possuir um valor envia para o destinatário do combobox e limpa o campo de mensagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSendMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbEvents.Text))
            {
                Movements message = new Movements();
                if (comboBox1.SelectedItem.ToString() == "Todos")
                    message.SendMessage("0", tbMessage.Text);
                else
                    message.SendMessage(comboBox1.SelectedItem.ToString(), tbMessage.Text);
                
            }
            tbMessage.Text = string.Empty;
        }
    }
}
