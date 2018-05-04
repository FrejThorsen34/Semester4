using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_ATM_Handin3.System.Interfaces
{
    public interface ITrack
    {
        string Tag { get; set; }
        DateTime Timestamp { get; set; }
        Point Position { get; set; }
        double Velocity { get; set; }
        double Course { get; set; }
        void CreateTrack(string payload);
    }
}
