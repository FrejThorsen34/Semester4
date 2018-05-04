using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_ATM_Handin3.System.Interfaces;

namespace SWT_ATM_Handin3.System.Domain
{
    public class SeparationOperations : ISeparationOperations
    {
        public bool CalculateSeparations(List<ITrack> trackList)
        {
            if (trackList.Count < 1)
                return false;

        }
    }
}
