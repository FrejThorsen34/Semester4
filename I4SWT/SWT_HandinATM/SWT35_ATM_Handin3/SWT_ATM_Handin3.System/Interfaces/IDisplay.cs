﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_ATM_Handin3.System.Interfaces
{
    public interface IDisplay
    {
        void Write(string output);
        void WriteRed(string output);
        void Clear();
    }
}
