using System;
using System.Collections.Generic;
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
        /// The PORT
        /// </summary>
        const int PORT = 9000;
        /// <summary>
        /// The BUFSIZE
        /// </summary>
        const int BUFSIZE = 1000;
        /// <summary>
        /// The Filename
        /// </summary>
        string fileName { get; set; }

        private file_server()
        {
            var size = 0;
            Console.WriteLine(" >> Server Started");
            Link link = new Link(1000, "FILE_SERVER");

            while (true)
            {

                Console.WriteLine(" >> Accept connection from NEW client");

                size = 0;

                do
                {

                    //reads filename from client
                    //size = LIB.check_File_Exists (fileName); //checks if file exist
                    //Send size to client
                    String test = "0101AFBGA"; // ABCFBDGBCA
                    byte[] toSend = Encoding.ASCII.GetBytes(test);
                    link.send(toSend, toSend.Length);
                    size = 1;

                } while (size == 0); //Check if file exist 


                Console.WriteLine(" >> Connection closed with THIS client");
                break;
            }
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
        /// <param name='tl'>
        /// Tl.
        /// </param>
        private void sendFile(String fileName, long fileSize, Transport transport)
        {
            // TO DO Your own code
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Server starts...");
            var myserver = new file_server();
        }
    }
}
