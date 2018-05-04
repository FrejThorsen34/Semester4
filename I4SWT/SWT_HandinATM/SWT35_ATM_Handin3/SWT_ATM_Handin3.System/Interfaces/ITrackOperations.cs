using System;
using System.Collections.ObjectModel;

namespace SWT_ATM_Handin3.System.Interfaces
{
    public interface ITrackOperations
    {
        ObservableCollection<ITrack> FlightTracks { get; }

        void AddTrack(string payload);
        void DeleteTrack(ITrack track);
        void Update();
        double CalculateVelocity(Point oldPoint, Point newPoint, DateTime newTimestamp, DateTime oldTimestamp);
        double CalculateCourse(Point oldPoint, Point newPoint);
        ObservableCollection<ITrack> GetAll();
    }
}