﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_ATM_Handin3.System.Interfaces;

namespace SWT_ATM_Handin3.System.Domain
{
    public class TrackOperations : ITrackOperations
    {
        public ObservableCollection<ITrack> FlightTracks { get; }

        public TrackOperations()
        {
            FlightTracks = new ObservableCollection<ITrack>();
        }

        public void AddTrack(string payload)
        {
            FlightTracks.Add(new Track(payload));
        }

        public void DeleteTrack(ITrack track)
        {
            FlightTracks.Remove(track);
        }

        public ObservableCollection<ITrack> GetAll()
        {
            return FlightTracks;
        }

        public void Update()
        {

        }

        public double CalculateCourse(Point oldPoint, Point newPoint)
        {
            double Y = Math.Abs(newPoint.Y - oldPoint.Y);
            double X = Math.Abs(newPoint.X - oldPoint.X);
            double compassCourse = Math.Atan2(Y, X) * (180 / Math.PI);

            //No direction
            if (X == 0 && Y == 0)
            {
                return Double.NaN;
            }
            //NorthSouth-Direction
            else if (X == 0)
            {
                //South
                if (newPoint.Y < oldPoint.Y)
                    compassCourse = 180;
                //North
                else
                    compassCourse = 0;
            }
            //EastWest-Direction
            else if (Y == 0)
            {
                //West
                if (newPoint.X < oldPoint.X)
                    compassCourse = 270;
                //East
                else
                    compassCourse = 90;
            }
            //West
            else if (newPoint.X < oldPoint.X)
            {
                //South
                if (newPoint.Y < oldPoint.Y)
                    compassCourse += 180;
                //North
                else
                    compassCourse += 270;
            }
            //East
            else if (newPoint.X > oldPoint.X)
            {
                //South
                if (newPoint.Y < oldPoint.Y)
                    compassCourse += 90;
            }

            return compassCourse;
        }

        public double CalculateVelocity(Point oldPoint, Point newPoint, DateTime oldTimestamp, DateTime newTimestamp)
        {
            TimeSpan diff = newTimestamp.Subtract(oldTimestamp);
            var timeDifference = diff.TotalSeconds;
            var distance = Math.Sqrt(Math.Pow((newPoint.X - oldPoint.X), 2) + Math.Pow((newPoint.Y - oldPoint.Y), 2));
            var velocity = distance / timeDifference;

            return velocity;
        }
    }
}
