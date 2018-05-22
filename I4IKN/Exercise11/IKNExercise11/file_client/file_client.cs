using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using LinkLayer;
using TransportLayer;
using LIB;
using LIB = LIB.LIB;

namespace file_client
{
    class file_client
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
        /// Initializes a new instance of the <see cref="file_client"/> class.
        /// 
        /// file_client metoden opretter en peer-to-peer forbindelse
        /// Sender en forspÃ¸rgsel for en bestemt fil om denne findes pÃ¥ serveren
        /// Modtager filen hvis denne findes eller en besked om at den ikke findes (jvf. protokol beskrivelse)
        /// Lukker alle streams og den modtagede fil
        /// Udskriver en fejl-meddelelse hvis ikke antal argumenter er rigtige
        /// </summary>
        /// <param name='args'>
        /// Filnavn med evtuelle sti.
        /// </param>
        private file_client(String[] args)
        {
            // TO DO Your own code

            if (args.Length != 1)
                Environment.Exit(0);

            // Initialize
            byte[] sizeArr = new byte[BUFSIZE];
            string filename = args[0];

            Console.WriteLine($"Requesting the file {args[0]}");

            // Send the filename using the transportlayer
            _transport.Send(Encoding.ASCII.GetBytes(filename), Encoding.ASCII.GetBytes(filename).Length);

            // Receive the request file size
            int receiveSize = _transport.Receive(ref sizeArr);

            if(Encoding.ASCII.GetString(sizeArr).Substring(0, receiveSize) == "0")
                Console.WriteLine($"Requested file named {filename} was not found.");
            else
            {
                Console.WriteLine($"Size of the requested file: {Encoding.ASCII.GetString(sizeArr)}");
                receiveFile(filename, long.Parse(Encoding.ASCII.GetString(sizeArr)), _transport);
            }
        }

        /// <summary>
        /// Receives the file.
        /// </summary>
        /// <param name='fileName'>
        /// File name.
        /// </param>
        /// <param name="fileSize">
        /// Size of the file.
        /// </param>
        /// <param name='transport'>
        /// Transportlaget
        /// </param>

        private void receiveFile(String fileName, long fileSize, Transport transport)
        {
            // TO DO Your own code
            // Directory for saving the file
            string directory = "/root/Desktop/TransferredFiles/";
            Directory.CreateDirectory(directory);

            //Creating the file on client server, so we need to Create and Write.
            FileStream file = new FileStream(directory + fileName, FileMode.Create, FileAccess.Write);

            // Receiving the data in chunks of 1000 bytes
            byte[] bufSize = new byte[BUFSIZE];
            int total = 0;

            Console.WriteLine("Receiving the file...");
            while (fileSize > total)
            {
                int dataRead = _transport.Receive(ref bufSize);
                file.Write(bufSize, 0, dataRead);
                total = total + dataRead;
            }
            Console.WriteLine("File received!");
            file.Close();
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name='args'>
        /// First argument: Filname
        /// </param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting the client.");
            new file_client(args);
        }
    }
}
