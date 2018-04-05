using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

namespace tcp
{
    class file_client
    {
        /// <summary>
        /// The PORT.
        /// </summary>
        const int PORT = 9000;
        /// <summary>
        /// The BUFSIZE.
        /// </summary>
        const int BUFSIZE = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="file_client"/> class.
        /// </summary>
        /// <param name='args'>
        /// The command-line arguments. First ip-adress of the server. Second the filename
        /// </param>
        private file_client(string[] args)
        {
            //Try to connect to remote decide
            try
            {
                // Create the remote endpoint for socket and the TCP/IP socket
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(args[0]), PORT);
                Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the endpoint
                try
                {
                    // Connect
                    client.Connect(endPoint);

                    // Message
                    string filename = args[1];

                    // Create networkstream and connect to socket
                    NetworkStream networkStream = new NetworkStream(client);

                    // Receive file
                    receiveFile(filename, networkStream);
                }
                // Exception handling
                catch (ArgumentNullException an)
                {
                    Console.WriteLine($"ArgumentNullException: {an.ToString()}");
                }
                catch (SocketException s)
                {
                    Console.WriteLine($"SocketException: {s.ToString()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unspecified exception: {e.ToString()}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Receives the file.
        /// </summary>
        /// <param name='fileName'>
        /// File name.
        /// </param>
        /// <param name='io'>
        /// Network stream for reading from the server
        /// </param>
        private void receiveFile(String fileName, NetworkStream io)
        {
            // TO DO Your own code
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name='args'>
        /// The command-line arguments.
        /// </param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Client starts...");
            new file_client(args);
        }
    }
}