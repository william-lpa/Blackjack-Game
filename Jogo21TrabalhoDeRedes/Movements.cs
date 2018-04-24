using Jogo21TrabalhoDeRedes.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jogo21TrabalhoDeRedes.Jogo
{
    public enum Status { IDLE, PLAYING, GETTING, WAITING }
    class Movements
    {
       private  TCPIP tcp;
       private UDP udp;
       public static List<Card> Cards { get; set; } = new List<Card>();
       public static Status CurrentStatus { get;
            set; }
       public string[] Players { get; set; }
        public string[] Users { get; set; }


        /// <summary>
        ///    KeepAlive. Monitora se retorna usuários. Se sim, conexão OK.
        /// </summary>
        /// <returns></returns>
        public bool KeepAlive()
        {
            Thread.Sleep(6000);
            string users = tcp.GetUsers();
            if (users != "") //get players and getMessages
            {
                GetUsers(users);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Pega os jogadores que retorna da msg TCP e separa eles em arrays.
        /// </summary>
        /// <returns></returns>
        public string [] GetPlayers()
        {
           string [] playersAndStatus = tcp.GetPlayers().Replace(":\r\n", "").Split(':');
           string [] players = new string[playersAndStatus.Length/2];
            string currentPlayer = "";
            for (int i = 0, j = 0; i < playersAndStatus.Length; i++)
            {
                currentPlayer += playersAndStatus[i]+"-";
                if (i % 2 != 0)
                {
                    currentPlayer = currentPlayer.Remove(currentPlayer.LastIndexOf('-'), 1);
                    players[j] = currentPlayer;
                    j++;
                    currentPlayer = "";
                }

            }
            Players = players;
            RefreshPlayerStatus(Players.Where(x => x.Split('-')[0]==tcp.UserID).Select(x => x.Split('-')[1]).FirstOrDefault());
            return Players;
        }

        /// <summary>
        /// Pega os usuários que retorna da msg TCP e separa em arrays. Chamado pelo KeepAlive. Como ele ja chama essa msg, ele já separa em array pra n ter que chamar 2x
        /// </summary>
        /// <param name="currentUsers"></param>
        /// <returns></returns>
        private string[] GetUsers(string currentUsers)
        {
            string[] UsersAndWins = currentUsers.Replace(":\r\n","").Split(':');
            string[] users = new string[UsersAndWins.Length / 3];
            string currentUser = "";
            for (int i = 1, j = 0; i <= UsersAndWins.Length; i++)
            {
                currentUser += UsersAndWins[i-1] + "-";
                if (i % 3 == 0)
                {
                    currentUser = currentUser.Remove(currentUser.LastIndexOf('-'), 1);
                    users[j] = currentUser;
                    j++;
                    currentUser = "";
                }

            }
            Users = users;
            
            return Users;
        }

        /// <summary>
        /// Atualiza o status atual do jogo. Chamado pelo GetPlyers, que é chamado a cada 6 segundos pelo KeepAlive.
        /// </summary>
        /// <param name="playersAndStatus"></param>
        private void RefreshPlayerStatus(string playersAndStatus)
        {
            if(playersAndStatus!=null)
            CurrentStatus = (Status)Enum.Parse(typeof(Status),playersAndStatus?.Trim());
        }

        /// <summary>
        /// Mão de cartas. Exemplo: {K-Spades;9-Diamonds}
        /// </summary>
        /// <returns></returns>
        public string ShowTableCards()
        {
            string cards = "{";

            foreach (var card in Movements.Cards)
            {
                cards += card.ToString() +";" ;
            }
            cards = cards.Remove(cards.LastIndexOf(";"), 1);
            return cards+"}";
        }

        /// <summary>
        /// Pontuação Atual. É a soma da Propriedade Valor de todas as cartas armazenadas na lista.
        /// </summary>
        /// <returns></returns>
        public int CurrentSum()
        {
            return Cards.Sum(card => card.Valor);
        }
        

        /// <summary>
        /// Chama a mensagem UDP para enviar uma menssagem quando solicitada
        /// </summary>
        /// <param name="to"></param>
        /// <param name="message"></param>
        public void SendMessage(string to, string message)
        {
            udp.SendMessage(to, message);
        }

        /// <summary>
        /// Retorna sempre a ultima mensagem para o usuário que está jogando.
        /// </summary>
        /// <returns></returns>
        public string getOldestMessage()
        {
            string message= tcp.GetTheOldestMessage();

            if (message == ":\r\n")
                return string.Empty;
            else
                return message;
        }

        //Cosntrutor...
        public Movements()
        {
            tcp = TCPIP.Instance;
            udp = UDP.Instance;
            
        }

        /// <summary>
        /// Solicita por mensagem UDP para entrar no jogo.
        /// </summary>
        public void JoinGame()
        {
            try
            {
                udp.InteractServer(UDP.Action.ENTER);
                CurrentStatus = Status.IDLE;
            }
            catch (Exception err)
            {

                throw;
            }

        }

        /// <summary>
        /// Solicita por mensagem UDP para sair no jogo.
        /// </summary>
        public void QuitGame()
        {
            udp.InteractServer(UDP.Action.QUIT);
        }

        /// <summary>
        /// Solciita ao servidor por TCPIP mais uma carta e armazena na lista de cartas
        /// </summary>
        public void GetNextCard()
        {
            if (CurrentStatus == Status.GETTING)
            {
                string cardMessage = tcp.GetCard();
               string [] card = cardMessage.Replace("\r\n","").Split(':');
                Card c = new Card();
                c.Name = card[0];
                c.Suit = (Suit) Enum.Parse(typeof(Suit),card[1]);
                Cards.Add(c);
                //notify interface new Card;
            }
            else
                throw new ArgumentException("Não é possível solicitar uma carda no momento");
        }

        /// <summary>
        /// Avisa por UDP ao servidor para passar a vez.
        /// </summary>
        public void StopGettingCardTurn()
        {
            udp.InteractServer(UDP.Action.STOP);
            CurrentStatus = Status.WAITING;
        }
    }
}
