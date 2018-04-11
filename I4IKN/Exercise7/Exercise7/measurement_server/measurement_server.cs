using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace measurement_server
{
    public class measurement_server
    {
        /// <summary>
        /// The PORT
        /// </summary>
        const int PORT = 9000;

        private measurement_server()
        {
            // Create local IPEndPoint
            IPEndPoint endPointLocal = new IPEndPoint(IPAddress.Any, PORT);
            // Create UdpClient and Socket
            UdpClient server_udp = new UdpClient(endPointLocal);
            Socket server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Create sending IPEndPoint
            IPEndPoint endPointSend = new IPEndPoint(endPointLocal.Address, PORT);

            string received;
            byte[] send;

            while (true)
            {
                Console.WriteLine("Listening...");

                received = Encoding.ASCII.GetString(server_udp.Receive(ref endPointLocal));
                
                Console.WriteLine("Connected!");

                switch (received)
                {
                    case "u":
                    case "U":
                        send = Encoding.ASCII.GetBytes(File.ReadAllText("/proc/uptime"));
                        try
                        {
                            Console.WriteLine("Sending uptime.");
                            server_socket.SendTo(send, endPointSend);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            throw;
                        }

                        break;
                    case "l":
                    case "L":
                        send = Encoding.ASCII.GetBytes(File.ReadAllText("/proc/loadavg"));
                        try
                        {
                            Console.WriteLine("Sending loadavg.");
                            server_socket.SendTo(send, endPointSend);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            throw;
                        }

                        break;
                    default:
                        send = Encoding.ASCII.GetBytes("Invalid");
                        Console.WriteLine("Invalid request.");
                        try
                        {
                            server_socket.SendTo(send, endPointSend);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            throw;
                        }

                        break;
                }

                Console.WriteLine("Handling complete");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("UDP Server starting.");
            new measurement_server();
        }
    }
}
