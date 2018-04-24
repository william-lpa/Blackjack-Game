namespace Jogo21TrabalhoDeRedes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btStartQuitGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridConnUsers = new System.Windows.Forms.DataGridView();
            this.dataGridPlayingUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCards = new System.Windows.Forms.TextBox();
            this.btRequestCard = new System.Windows.Forms.Button();
            this.btStopTurn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEvents = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btSendMessage = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbScore = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConnUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayingUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btStartQuitGame
            // 
            this.btStartQuitGame.Location = new System.Drawing.Point(269, 275);
            this.btStartQuitGame.Name = "btStartQuitGame";
            this.btStartQuitGame.Size = new System.Drawing.Size(113, 42);
            this.btStartQuitGame.TabIndex = 0;
            this.btStartQuitGame.Text = "Jogar";
            this.btStartQuitGame.UseVisualStyleBackColor = true;
            this.btStartQuitGame.Click += new System.EventHandler(this.btStartQuitGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuários Conectados:";
            // 
            // dataGridConnUsers
            // 
            this.dataGridConnUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConnUsers.Location = new System.Drawing.Point(129, 12);
            this.dataGridConnUsers.Name = "dataGridConnUsers";
            this.dataGridConnUsers.Size = new System.Drawing.Size(427, 101);
            this.dataGridConnUsers.TabIndex = 2;
            // 
            // dataGridPlayingUsers
            // 
            this.dataGridPlayingUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlayingUsers.Location = new System.Drawing.Point(129, 123);
            this.dataGridPlayingUsers.Name = "dataGridPlayingUsers";
            this.dataGridPlayingUsers.Size = new System.Drawing.Size(427, 101);
            this.dataGridPlayingUsers.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jogando:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cartas:";
            // 
            // tbCards
            // 
            this.tbCards.Location = new System.Drawing.Point(76, 323);
            this.tbCards.Name = "tbCards";
            this.tbCards.ReadOnly = true;
            this.tbCards.Size = new System.Drawing.Size(464, 20);
            this.tbCards.TabIndex = 7;
            // 
            // btRequestCard
            // 
            this.btRequestCard.Location = new System.Drawing.Point(177, 361);
            this.btRequestCard.Name = "btRequestCard";
            this.btRequestCard.Size = new System.Drawing.Size(115, 41);
            this.btRequestCard.TabIndex = 8;
            this.btRequestCard.Text = "Solicitar Carta";
            this.btRequestCard.UseVisualStyleBackColor = true;
            this.btRequestCard.Click += new System.EventHandler(this.btRequestCard_Click);
            // 
            // btStopTurn
            // 
            this.btStopTurn.Location = new System.Drawing.Point(388, 361);
            this.btStopTurn.Name = "btStopTurn";
            this.btStopTurn.Size = new System.Drawing.Size(115, 41);
            this.btStopTurn.TabIndex = 9;
            this.btStopTurn.Text = "Passar A Vez";
            this.btStopTurn.UseVisualStyleBackColor = true;
            this.btStopTurn.Click += new System.EventHandler(this.btStopTurn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Eventos:";
            // 
            // tbEvents
            // 
            this.tbEvents.Location = new System.Drawing.Point(15, 459);
            this.tbEvents.Name = "tbEvents";
            this.tbEvents.Size = new System.Drawing.Size(541, 96);
            this.tbEvents.TabIndex = 11;
            this.tbEvents.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 576);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mensagem:";
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(80, 569);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(329, 20);
            this.tbMessage.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Todos"});
            this.comboBox1.Location = new System.Drawing.Point(419, 568);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // btSendMessage
            // 
            this.btSendMessage.Location = new System.Drawing.Point(216, 600);
            this.btSendMessage.Name = "btSendMessage";
            this.btSendMessage.Size = new System.Drawing.Size(117, 31);
            this.btSendMessage.TabIndex = 15;
            this.btSendMessage.Text = "Enviar Mensagem";
            this.btSendMessage.UseVisualStyleBackColor = true;
            this.btSendMessage.Click += new System.EventHandler(this.btSendMessage_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Pontuação:";
            // 
            // tbScore
            // 
            this.tbScore.Location = new System.Drawing.Point(76, 372);
            this.tbScore.Name = "tbScore";
            this.tbScore.ReadOnly = true;
            this.tbScore.Size = new System.Drawing.Size(51, 20);
            this.tbScore.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Seu Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(92, 261);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 16);
            this.labelStatus.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "User ID:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(177, 248);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(153, 20);
            this.tbUser.TabIndex = 21;
            this.tbUser.Text = "9260";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(388, 245);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(161, 20);
            this.tbPassword.TabIndex = 23;
            this.tbPassword.Text = "defon";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(341, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Senha:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 644);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSendMessage);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbEvents);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btStopTurn);
            this.Controls.Add(this.btRequestCard);
            this.Controls.Add(this.tbCards);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridPlayingUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridConnUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btStartQuitGame);
            this.Name = "Form1";
            this.Text = "Jogo 21";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConnUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayingUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStartQuitGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridConnUsers;
        private System.Windows.Forms.DataGridView dataGridPlayingUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCards;
        private System.Windows.Forms.Button btRequestCard;
        private System.Windows.Forms.Button btStopTurn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox tbEvents;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btSendMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbScore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label9;
    }
}

