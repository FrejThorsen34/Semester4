using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating server object");
            var Server = new UdpServer();

            Console.WriteLine("Running server");
            Server.Run();
        }
    }
}
