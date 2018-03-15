using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFoundation.Wpf;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Serialization;

namespace GUIAssignment
{
    public class Player
    {
        private string _name;
        private uint _kills;
        private uint _deaths;
        private uint _gamesPlayed;
        private uint _gamesWon;
        private double _points;

        public Player()
        {
        }

        public Player(string name, uint kills, uint deaths, uint gamesPlayed)
        {
            Name = name;
            Kills = kills;
            Deaths = deaths;
            GamesPlayed = gamesPlayed;
        }

        public uint SettingGamesWon()
        {
            uint gamesWon = (this.GamesPlayed - this.Deaths);
            return gamesWon;
        }

        public double SettingPoints()
        {
            double points = (this.GamesWon * 10) + (this.Kills * 3) - (this.Deaths * 2);
            return points;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public uint Kills
        {
            get { return _kills;}
            set { _kills = value; }
        }

        public uint Deaths
        {
            get { return _deaths; }
            set { _deaths = value; }
        }

        public uint GamesPlayed
        {
            get { return _gamesPlayed; }
            set { _gamesPlayed = value; }
        }

        public double Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public uint GamesWon
        {
            get { return _gamesWon; }
            set { _gamesWon = value; }
        }
    }
}
