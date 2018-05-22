using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkLayer;
using TransportLayer;

namespace file_server
{
    class file_server
    {
        /// <summary>
        /// The BUFSIZE.
        /// </summary>
        private const int BUFSIZE = 1000;
        private const string APP = "FILE_CLIENT";
        /// <summary>
        /// The transportlayer.
        /// </summary>
        private Transport _transport = new Transport(BUFSIZE, APP);

        /// <summary>
        /// Initializes a new instance of the <see cref="file_server"/> class.
        /// </summary>
        private file_server()
        {
            // TO DO Your own code
        }

        /// <summary>
        /// Sends the file.
        /// </summary>
        /// <param name='fileName'>
        /// File name.
        /// </param>
        /// <param name='fileSize'>
        /// File size.
        /// </param>
        /// <param name='transport'>
        /// Transportlaget.
        /// </param>
        private void sendFile(String fileName, long fileSize, Transport transport)
        {
            // TO DO Your own code

            // Reading the file on server side, so need to Open and Read
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            // Sending in chunks of 1000 bytes untill theres nothing more to send.
            byte[] bufSize = new byte[BUFSIZE];
            int total = file.Read(bufSize, 0, bufSize.Length);

            Console.WriteLine("Sending file...");

            while (total > 0)
            {
                _transport.Send(bufSize, total);
                total = file.Read(bufSize, 0, bufSize.Length);
            }

            Console.WriteLine("File sent!");
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name='args'>
        /// The command-line arguments.
        /// </param>
        public static void Main(string[] args)
        {
            new file_server();
        }
    }
}
