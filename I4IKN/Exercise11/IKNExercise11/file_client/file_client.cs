using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using LinkLayer;

namespace file_client
{
    class file_client
    {
        /// <summary>
        /// The PORT
        /// </summary>
        const int PORT = 9000;
        /// <summary>
        /// The BUFSIZE
        /// </summary>
        const int BUFSIZE = 1000;

        private file_client(string[] args)
        {
            string filename;
            byte[] bytes = new byte[BUFSIZE];

            Link myLink = new Link(BUFSIZE, "FILE_CLIENT");
            myLink.receive(ref bytes);

            Console.WriteLine(bytes.ToString());
        }

        private void receiveFile(string fileName, NetworkStream io)
        {
            //Receive file
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client");
            var myClient = new file_client(args);
        }
    }
}
