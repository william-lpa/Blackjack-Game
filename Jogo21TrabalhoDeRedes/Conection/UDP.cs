using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Jogo21TrabalhoDeRedes.Conexao
{
    class UDP
    {

        private const int port = 1011;
        private  string server;
        public enum Action {ENTER, STOP, QUIT}

        public string UserID { get; set; }
        public string Password { get; set; }
        private static UDP instance;

        public static int Port
        {
            get
            {
                return port;
            }
           
        }

        public static UDP Instance
        {
            get
            {
                if (instance == null)
                    instance = new UDP();
                return instance;
            }
        }
        public string Server
        {
            get
            {
                return server;
            }
            set { server = value; }
        }


        private UDP()
        {
            
        }


        public void SendMessage(string To, string message)
        {
            UdpClient udpClient = new UdpClient(port);
            try
            {
                udpClient.EnableBroadcast = true;
                // udpClient.Connect(server, port);
                string messageSend = $"SEND MESSAGE {UserID}:{Password}:{To}:{message}\r\n";
               // string messageSend = "SEND MESSAGE 9260:defon:9366:Ola,teste";
                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.UTF8.GetBytes(messageSend);
                udpClient.Send(sendBytes, sendBytes.Length,server,port);
                udpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



        public void InteractServer(Action action)
        {
            UdpClient udpClient = new UdpClient(port);
            try
            {
                udpClient.Connect(server, port);

                string messageSend = $"SEND GAME {UserID}:{Password}:{action.ToString()}\r\n";
                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.UTF8.GetBytes(messageSend);

                udpClient.Send(sendBytes, sendBytes.Length);

                udpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

    }
}
