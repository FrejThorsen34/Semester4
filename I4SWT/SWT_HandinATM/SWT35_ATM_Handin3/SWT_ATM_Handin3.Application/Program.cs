using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_ATM_Handin3.System;
using SWT_ATM_Handin3.System.Interfaces;
using TransponderReceiver;

namespace SWT_ATM_Handin3.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransponderReceiver transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            ITrackingSystem trackingSystem = new TrackingSystem(transponderReceiver);

            Console.ReadLine();
        }
    }
}
