﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_ATM_Handin3.System
{
    public class SeparationEvent : EventArgs
    {
        public SeparationEvent(string tag1, string tag2, DateTime time)
        {
            Tag1 = tag1;
            Tag2 = tag2;
            Time = time;
        }
        public string Tag1 { get; }
        public string Tag2 { get; }
        public DateTime Time { get; }
    }
}
