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
        public event EventHandler<SeparationEvent> SeparationEvent;
        public void CheckForSeparations(List<ITrack> flightTracks)
        {
            foreach (var trackOne in flightTracks)
            {
                foreach (var trackTwo in flightTracks)
                {
                    if (trackOne.Tag != trackTwo.Tag)
                    {
                        if (CalculateSeparation(trackOne.Position, trackTwo.Position))
                        {
                            NewSeparationEvent(new SeparationEvent(trackOne.Tag, trackTwo.Tag, trackOne.Timestamp));
                            // SeparationDetected er flyttet over i TrackingSystem
                            // Logger behøves heller ikke være her
                            // Det at slette forældede separations er også flyttet til TrackingSystem
                        }
                    }
                }
            }
        }

        // Need to return all tracks that dont hold Separations
        public List<string> CheckForOutdatedSeparationEvents(List<ITrack> flightTracks)
        {
            List<string> list = new List<string>();
            foreach (var trackOne in flightTracks)
            {
                foreach (var trackTwo in flightTracks)
                {
                    if (trackOne.Tag != trackTwo.Tag)
                        if (!CalculateSeparation(trackOne.Position, trackTwo.Position))                       
                            if (!list.Contains(trackOne.Tag))
                                list.Add(trackOne.Tag + ";" + trackTwo.Tag);        
                    // This might be overkill. Theres gonna be a lot of operations.
                    if (!trackOne.WithinAirspace)
                        if (!list.Contains(trackOne.Tag))
                            list.Add(trackOne.Tag + ";" + trackTwo.Tag);
                }
            }
            return list;
        }

        public bool CalculateSeparation(Point trackOne, Point trackTwo)
        {
            if (Math.Abs(trackOne.Altitude - trackTwo.Altitude) <= 300)
            {
                var xsqr = Math.Pow(trackOne.X - trackTwo.X, 2);
                var ysqr = Math.Pow(trackOne.Y - trackTwo.Y, 2);
                if (Math.Sqrt(xsqr + ysqr) <= 5000)              
                    return true;
                return false;
            }
            return false;
        }

        protected virtual void NewSeparationEvent(SeparationEvent e)
        {
            SeparationEvent?.Invoke(this, e);
        }
    }
}
