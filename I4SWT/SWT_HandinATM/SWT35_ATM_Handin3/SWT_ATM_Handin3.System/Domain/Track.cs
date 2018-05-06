using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_ATM_Handin3.System.Interfaces;

namespace SWT_ATM_Handin3.System
{
    public class Track : ITrack
    {
        public string Tag { get; set; }
        public Point Position { get; set; }
        public DateTime Timestamp { get; set; }        
        public double Velocity { get; set; }
        public double Course { get; set; }
        public bool WithinAirspace { get; set; }

        public Track(string payload)
        {
            CreateTrack(payload);
        }

        public void CreateTrack(string payload)
        {
            try
            {
                var split = payload.Split(';');
                Tag = split[0];
                Position = new Point(Int32.Parse(split[1]), Int32.Parse(split[2]), Int32.Parse(split[3]));
                Timestamp = DateTime.ParseExact(split[4], "yyyyMMddHHmmssfff", null);
            }
            catch (FormatException)
            {
                throw;
            }
        }
    }
}
