using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_ATM_Handin3.System.Interfaces
{
    public interface IAirspace
    {
        Point LowerBound { get; }
        Point UpperBound { get; }
        bool CalculateWithinAirspace(Point trackPoint);
    }
}
