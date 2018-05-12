using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HackMan.Game
{
    public class Client
    {
        const int PORT = 9000;
        public UdpClient udpClient;
        IPEndPoint RemoteIpEndPoint;
        IPEndPoint LocalIpEndPoint;
        UdpClient listener;
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        public Client(IPAddress address)
        {
            udpClient = new UdpClient();
            RemoteIpEndPoint = new IPEndPoint(address, PORT);
            LocalIpEndPoint = new IPEndPoint(IPAddress.Any, PORT);
            listener = new UdpClient(LocalIpEndPoint);
            listener.Client.ReceiveTimeout = 250;
            //Connect to server
            udpClient.Connect(RemoteIpEndPoint);
        }

        public void Connect(string input)
        {
            //Connect to server
            udpClient.Connect(RemoteIpEndPoint);
        }

        public void Send(string input)
        {
            //Create Bytes to send
            Byte[] sendBytes = Encoding.ASCII.GetBytes(input);

            //Send Bytes to the server
            int bytesSent = udpClient.Send(sendBytes, sendBytes.Length);
            sendDone.WaitOne();
        }

        public string Receive()
        {
            string received;

            try
            {
                received = Encoding.ASCII.GetString(listener.Receive(ref LocalIpEndPoint));
                receiveDone.WaitOne();
            }
            catch (Exception e)
            {
                received = "connectionfailed";
            }

            return received;
        }
    }
}
