﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_ATM_Handin3.System.Boundary;
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
        public ILogger Logger { get; set; } = new Logger();
        public IDisplay Display { get; set; } = new Display();

        public TrackingSystem(ITransponderReceiver receiver)
        {
            Receiver = receiver;
            receiver.TransponderDataReady += DataReceived;
            SeparationOperations.SeparationEvent += SeparationDetected;
        }

        public void DataReceived(object o, RawTransponderDataEventArgs args)
        {
            //Add or update tracks
            foreach (var track in args.TransponderData)
            {
                TrackOperations.AddOrUpdate(track);
            }

            //Check if tracks are in airspace
            foreach (var track in TrackOperations.GetAll())
            {
                track.WithinAirspace = Airspace.CalculateWithinAirspace(track.Position);
            }

            //Check for Separations
            if (TrackOperations.GetAll().Count > 1)
                    SeparationOperations.CheckForSeparations(TrackOperations.GetAll().ToList());

            //Check for outdated separations
            UpdateOldSeparations();

            //Display everything
            OutputTerminal();
        }

        public void SeparationDetected(object sender, SeparationEvent se)
        {
            var separation = new SeparationEvent(se.Tag1, se.Tag2, se.Time);
            SeparationRepository.AddSeperationEvent(separation);
            Logger.WriteToFile(separation.Tag1 + ";" + separation.Tag2 + ";" + separation.Time);
        }
        
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
            var outdatedSeparations = SeparationOperations.CheckForOutdatedSeparationEvents(possiblyOutdatedSeparations);
            // Now delete all of these
            foreach (string sep in outdatedSeparations)
            {
                var split = sep.Split(';');
                var separationToRemove = SeparationRepository.Get(split[0], split[1]);
                if (separationToRemove != null)
                    SeparationRepository.DeleteSeperationEvent(separationToRemove);
            }
        }

        public void OutputTerminal()
        {
            Display.Clear();
            if (SeparationRepository.GetAll().Count != 0)
            {
                Display.WriteRed("Separation Event(s):");
                foreach (var sep in SeparationRepository.GetAll())
                    Display.WriteRed(sep.Tag1 + "/" + sep.Tag2 + " Time: " + sep.Time);
            }

            if (TrackOperations.GetAll().Count != 0)
            {
                Display.Write("Tracks:");
                foreach (var track in TrackOperations.GetAll())
                {
                    if (track.WithinAirspace)
                        Display.Write("Tag: " + track.Tag + " CurrentPosition: " + track.Position.X + "mE," +
                                  track.Position.Y +
                                  "mN Altitude: " + track.Position.Altitude + "m Velocity: " +
                                  Math.Round(track.Velocity, 2) + "m/s Course: " +
                                  Math.Round(track.Course, 2) + "°");
                }
            }
        }
    }
}
