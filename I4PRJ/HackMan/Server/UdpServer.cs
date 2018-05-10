using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class UdpServer
    {
        const int PORT = 9000;
        UdpClient UdpServerClient;
        IPEndPoint localIpEndPoint;
        IPEndPoint clientEndPoint;
        //Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //Ctor creates server
        public UdpServer()
        {
            //Assign port number
            UdpServerClient = new UdpClient(PORT);

            //Allows the server to read data sent from any source on PORT
            localIpEndPoint = new IPEndPoint(IPAddress.Any, PORT);
        }

        public void Send()
        {

        }

        public void Receive()
        {

        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    //blocks until message received & get IP
                    Byte[] receiveBytes = UdpServerClient.Receive(ref localIpEndPoint); //listen on port 9000
                    string returnData = Encoding.ASCII.GetString(receiveBytes);
                    clientEndPoint = new IPEndPoint(localIpEndPoint.Address, PORT);

                    Console.WriteLine("Received input: " + returnData);

                    string[] collection = returnData.Split(';');
                    switch (collection[0])
                    {
                        
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public bool AddGamesPlayed(string name, string password)
        {
            if (_repository.UpdateKill(name, password))
            {
                Console.WriteLine("GamesPlayed added");
                return true;
            }

            Console.WriteLine("Failed to add gamesPlayed");
            return false;
        }
    }
}
