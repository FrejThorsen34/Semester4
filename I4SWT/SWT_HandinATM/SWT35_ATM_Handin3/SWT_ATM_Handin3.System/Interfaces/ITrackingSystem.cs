using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace SWT_ATM_Handin3.System.Interfaces
{
    public interface ITrackingSystem
    {
        ITransponderReceiver Receiver { get; set; }
        IAirspace Airspace { get; set; }
        ITrackOperations TrackOperations { get; set; }
        ISeparationOperations SeparationOperations { get; set; }
        ISeparationRepository SeparationRepository { get; set; }
        void DataReceived(object o, RawTransponderDataEventArgs args);
        void SeparationDetected(object sender, SeparationEvent se);
        void UpdateOldSeparations();
    }
}
