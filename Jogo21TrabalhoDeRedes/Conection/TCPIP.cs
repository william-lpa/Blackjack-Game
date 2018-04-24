using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Jogo21TrabalhoDeRedes.Conexao
{
   public class TCPIP
    {
        private const int port = 1012;
        private  string server;
        private static TCPIP instance;
        public string UserID { get; set; }
        public string Password { get; set; }

        private TCPIP()
        {
            

        }

        public static TCPIP Instance
        { get
            {
                if (instance == null)
                    instance = new TCPIP();
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

        public string GetUsers()
        {
            String responseData = String.Empty;
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                TcpClient client = new TcpClient(server, port);
                string message = $"GET USERS {UserID}:{Password}\r\n";
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
                
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            return responseData;
        }
        public string GetTheOldestMessage()
        {
            string responseData = string.Empty;
            try
            {
                TcpClient client = new TcpClient(server, port);
                string message = $"GET MESSAGE {UserID}:{Password}\r\n";
               
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                data = new byte[256];

                
                int bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            return responseData;
        }
        public string GetPlayers()
        {
            string responseData = string.Empty;
            try
            {
                TcpClient client = new TcpClient(server, port);
                string message = $"GET PLAYERS {UserID}:{Password}\r\n";

                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                data = new byte[256];

                
                int bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            return responseData;
        }
        public string GetCard()
        {
          string responseData = string.Empty;
            try
            {
                TcpClient client = new TcpClient(server, port);
                string message = $"GET CARD {UserID}:{Password}\r\n";

                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                data = new byte[256];

                int bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                stream.Close();
                client.Close();
               
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            return responseData;
        }

    }
}
