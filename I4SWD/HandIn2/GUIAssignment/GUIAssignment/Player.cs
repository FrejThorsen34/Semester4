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
            get
            {
                double points = (GamesWon * 10) + (Kills * 3) - (Deaths * 2);
                return points;
            }
        }

        public uint GamesWon
        {
            get { return GamesPlayed - Deaths; }
        }
    }
}
