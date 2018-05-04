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

        public TrackingSystem(ITransponderReceiver receiver)
        {
            Receiver = receiver;
            receiver.TransponderDataReady += DataReceived;
        }

        private void DataReceived(object o, RawTransponderDataEventArgs args)
        {
            foreach (var track in args.TransponderData)
            {
                TrackOperations.AddTrack(track);
            }

            foreach (ITrack track in TrackOperations.GetAll())
            {
                if (!Airspace.CalculateWithinAirspace(track.Position))
                    TrackOperations.DeleteTrack(track);
            }

            TrackOperations.Update();
        }
    }
}
