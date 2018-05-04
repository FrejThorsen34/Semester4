using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_ATM_Handin3.System.Interfaces;

namespace SWT_ATM_Handin3.System.Boundary
{
    public class Logger : ILogger
    {
        private readonly string _filePathAndName;

        public Logger(string filePathAndName = null)
        {
            _filePathAndName = filePathAndName ?? "Log.txt";
        }

        public void WriteToFile(string output)
        {
            using (StreamWriter file = new StreamWriter(_filePathAndName, true))
                file.WriteLine(output);
        }
    }
}
