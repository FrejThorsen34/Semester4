using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_ATM_Handin3.System.Domain;
using SWT_ATM_Handin3.System.Interfaces;
using TransponderReceiver;

namespace SWT_ATM_Handin3.System
{
    public class TrackingSystem : ITrackingSystem
    {
        public ITransponderReceiver Receiver { get; set; }
        public IAirspace Airspace { get; set; } = new Airspace();
        public ITrackOperations TrackOperations { get; set; } = new TrackOperations();
        public ISeparationOperations SeparationOperations { get; set; } = new SeparationOperations();
        public ISeparationRepository SeparationRepository { get; set; } = new SeparationRepository();

        public TrackingSystem(ITransponderReceiver receiver)
        {
            Receiver = receiver;
            receiver.TransponderDataReady += DataReceived;
            SeparationOperations.SeparationEvent += SeparationDetected;
        }

        public void DataReceived(object o, RawTransponderDataEventArgs args)
        {
            UpdateOldSeparations();

            foreach (var track in args.TransponderData)
            {
                TrackOperations.AddOrUpdate(track);
            }

            foreach (ITrack track in TrackOperations.GetAll())
            {
                //Check Airspace
                if (!Airspace.CalculateWithinAirspace(track.Position))
                    TrackOperations.DeleteTrack(track);

                //Check for Separations
                if(TrackOperations.FlightTracks.Count > 1)
                    SeparationOperations.CheckForSeparations(TrackOperations.FlightTracks.ToList());
            }
            //Display functions?
        }

        public void SeparationDetected(object sender, SeparationEvent se)
        {
            var separation = new SeparationEvent(se.Tag1, se.Tag2, se.Time);
            SeparationRepository.AddSeperationEvent(separation);
        }
        // Do logic on SeparationRepository to get rid of outdated separations
        public void UpdateOldSeparations()
        {            
            // Find all separations
            var separationEvents = SeparationRepository.GetAll();
            // Find all tracks
            var tracks = TrackOperations.GetAll().ToList();
            // Find all tracks still on separationlist
            var possiblyOutdatedSeparations = separationEvents
                .Select(separations => tracks.FirstOrDefault(t => t.Tag == separations.Tag1)).ToList();
            // Find all tracks that shouldnt be on separationlist
            var outdatedSeparations = SeparationOperations.CheckForNoSeparationEvents(possiblyOutdatedSeparations);
            // Now delete all of these
            //foreach (ITrack track in outdatedSeparations)
            //    SeparationRepository.DeleteSeperationEvent(track);
        }
    }
}
