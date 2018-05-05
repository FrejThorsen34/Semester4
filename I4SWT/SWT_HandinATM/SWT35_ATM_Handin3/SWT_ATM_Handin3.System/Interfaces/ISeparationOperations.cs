using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_ATM_Handin3.System.Interfaces
{
    public interface ISeparationOperations
    {
        event EventHandler<SeparationEvent> SeparationEvent;
        void CheckForSeparations(List<ITrack> flightTracks);
        List<string> CheckForNoSeparationEvents(List<ITrack> flightTracks);
        bool CalculateSeparation(Point trackOne, Point trackTwo);
    }
}
