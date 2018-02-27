using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace file_client
{
    class FileClient
    {
        private static Socket _clientSocket =
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            Console.Title = "Client";
            LoopConnect();
            SendLoop();
            Console.ReadLine();
        }

        private static void SendLoop()
        {
            while (true)
            {
                Console.Write("Enter a request: ");
                string request = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(request);
                _clientSocket.Send(buffer);
                byte[] receivedBuf = new byte[1024];
                int receive = _clientSocket.Receive(receivedBuf);
                byte[] data = new byte[receive];
                Array.Copy(receivedBuf, data, receive);
                Console.WriteLine("Received: " + Encoding.ASCII.GetString(data));
            }
        }

        private static void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Loopback, 9000);
                }
                catch (SocketException)
                {
                    Console.Clear();
                    Console.WriteLine("Connection attemps: " + attempts.ToString());
                }
            }

            Console.Clear();
            Console.WriteLine("Connected");
        }
    }
}
