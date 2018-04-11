using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace tcp
{
    class file_server
    {
        /// <summary>
        /// The PORT
        /// </summary>
        const int PORT = 9000;
        /// <summary>
        /// The BUFSIZE
        /// </summary>
        const int BUFSIZE = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="file_server"/> class.
        /// Opretter en socket.
        /// Venter på en connect fra en klient.
        /// Modtager filnavn
        /// Finder filstørrelsen
        /// Kalder metoden sendFile
        /// Lukker socketen og programmet
        /// </summary>
        private file_server()
        {
            // Create the local endpoint for the socket and the TCP/IP socket
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);
            Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint
            try
            {
                server.Bind(endPoint);

                // Listen for connections
                server.Listen(10);
                while (true)
                {
                    Console.WriteLine("Listening...");

                    Socket handler = server.Accept();
                    // Create networkstream and connect it to socket
                    NetworkStream networkStream = new NetworkStream(handler);

                    string fileNameAndPath = LIB.readTextTCP(networkStream);
                    Console.WriteLine("Requested file: " + fileNameAndPath);

                    long fileSize = LIB.check_File_Exists(fileNameAndPath);

                    // If file doesnt exist, close the networkstream, shutdown the socket and close it
                    if (fileSize < 1)
                    {
                        Console.WriteLine("File not found!");
                        LIB.writeTextTCP(networkStream, "-1");
                        networkStream.Close();
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }
                    else
                    {
                        sendFile(fileNameAndPath, fileSize, networkStream);
                        networkStream.Close();
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        /// <summary>
        /// Sends the file.
        /// </summary>
        /// <param name='fileName'>
        /// The filename.
        /// </param>
        /// <param name='fileSize'>
        /// The filesize.
        /// </param>
        /// <param name='io'>
        /// Network stream for writing to the client.
        /// </param>
        private void sendFile(String fileName, long fileSize, NetworkStream io)
        {
            // TO DO Your own code
            LIB.writeTextTCP(io, fileSize.ToString());

            byte[] files = File.ReadAllBytes(fileName);

            int sent = 0;

            while (sent < fileSize)
            {
                if (fileSize - sent < BUFSIZE)
                {
                    io.Write(files, sent, (int) fileSize - sent);
                    sent += (int) fileSize - sent;
                }
                else
                {
                    io.Write(files, sent, BUFSIZE);
                    sent += BUFSIZE;
                }
            }
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name='args'>
        /// The command-line arguments.
        /// </param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Server starts...");
            new file_server();
        }
    }
}
