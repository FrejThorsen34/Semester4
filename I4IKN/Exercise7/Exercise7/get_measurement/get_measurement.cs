using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace get_measurement
{
    public class get_measurement
    {
        /// <summary>
        /// The PORT
        /// </summary>
        const int PORT = 9000;

        private get_measurement(string[] args)
        {
            // Create local IPEndPoint
            IPEndPoint endPointLocal = new IPEndPoint(IPAddress.Any, PORT);
            // Create UdpClient and socket
            UdpClient client = new UdpClient(endPointLocal);
            Socket client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Create sending IPEndPoint
            IPEndPoint endPointSend = new IPEndPoint(IPAddress.Parse(args[0]), PORT);

            byte[] send = Encoding.ASCII.GetBytes(args[1]);
            string received;

            try
            {
                client_socket.SendTo(send, endPointSend);
                Console.WriteLine("Getting measurement.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

            Console.WriteLine("Measurement from server: ");
            received = Encoding.ASCII.GetString(client.Receive(ref endPointLocal));
            Console.WriteLine(received);
        }

        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Enter IP and measurement request: ");
                Console.WriteLine("U for uptime or L for loadavg");
            }
            else
                new get_measurement(args);
        }
    }
}
