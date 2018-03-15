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
        private int _kills;
        private int _deaths;
        private int _gamesPlayed;
        private int _gamesWon;
        private int _points;

        public Player()
        {
        }

        public Player(string name, int kills, int deaths, int gamesPlayed)
        {
            Name = name;
            Kills = kills;
            Deaths = deaths;
            GamesPlayed = gamesPlayed;
            Points = SettingPoints();
            GamesWon = SettingGamesWon();
        }

        public int SettingGamesWon()
        {
            int gamesWon = (this.GamesPlayed - this.Deaths);
            return gamesWon;
        }

        public int SettingPoints()
        {
            int points = (this.GamesWon * 10) + (this.Kills * 3) - (this.Deaths * 2);
            return points;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Kills
        {
            get { return _kills;}
            set { _kills = value; }
        }

        public int Deaths
        {
            get { return _deaths; }
            set { _deaths = value; }
        }

        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            set { _gamesPlayed = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public int GamesWon
        {
            get { return _gamesWon; }
            set { _gamesWon = value; }
        }
    }
}
