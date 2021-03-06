﻿using System;
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

// ========== Authors ==========  //
// Gruppe 25 SWD: GUI Assignment  //
// Nickolai Lundby Ernst, NE84070 //
// Rune Keenaa Aagaard, 20105809  //
// =============================  //

namespace GUIAssignmentImproved
{
    public class PlayerViewModel : ObservableCollection<PlayerModel>, INotifyPropertyChanged, IPageViewModel
    {
        public static List<PlayerModel> _players = new List<PlayerModel>();
        public static List<string> _displayPlayers = new List<string>();
        PlayerModel _playerModel = new PlayerModel();
        private string _lastSort;
        private string _name = "Highscores";

        #region Commands

        ICommand _sortKillsCommand;

        public ICommand SortKillsCommand
        {
            get
            {
                return _sortKillsCommand ?? (_sortKillsCommand =
                           new RelayCommand(SortByKills, SortByKills_CanExecute));
            }
        }

        public void SortByKills()
        {
            List<PlayerModel> sortedList = _players.OrderByDescending(o => o.Kills).ToList();
            List<string> tempList = new List<string>();
            for (int rank = 0; rank < 10; rank++)
                tempList.Add(string.Format("{0} {1} {2}", rank + 1, sortedList[rank].Name, sortedList[rank].Kills));
            DisplayPlayers = tempList;
            LastSort = "Kills";
        }

        public bool SortByKills_CanExecute()
        {
            if (_players.Count > 0)
                return true;
            else
                return false;
        }

        ICommand _sortDeathsCommand;

        public ICommand SortDeathsCommand
        {
            get
            {
                return _sortDeathsCommand ??
                       (_sortDeathsCommand = new RelayCommand(SortByDeaths, SortByDeaths_CanExecute));
            }
        }

        public void SortByDeaths()
        {
            List<PlayerModel> sortedList = _players.OrderByDescending(o => o.Deaths).ToList();
            List<string> tempList = new List<string>();
            for (int rank = 0; rank < 10; rank++)
                tempList.Add(string.Format("{0} {1} {2}", rank + 1, sortedList[rank].Name, sortedList[rank].Deaths));
            DisplayPlayers = tempList;
            LastSort = "Deaths";
        }

        public bool SortByDeaths_CanExecute()
        {
            if (_players.Count > 0)
                return true;
            else
                return false;
        }

        ICommand _sortGamesPlayedCommand;

        public ICommand SortGamesPlayedCommand
        {
            get
            {
                return _sortGamesPlayedCommand ?? (_sortGamesPlayedCommand =
                           new RelayCommand(SortByGamesPlayedCommand, SortByGamesPlayedCommand_CanExecute));
            }
        }

        public void SortByGamesPlayedCommand()
        {
            List<PlayerModel> sortedList = _players.OrderByDescending(o => o.GamesPlayed).ToList();
            List<string> tempList = new List<string>();
            for (int rank = 0; rank < 10; rank++)
                tempList.Add(string.Format("{0} {1} {2}", rank + 1, sortedList[rank].Name, sortedList[rank].GamesPlayed));
            DisplayPlayers = tempList;
            LastSort = "Games played";
        }

        public bool SortByGamesPlayedCommand_CanExecute()
        {
            if (_players.Count > 0)
                return true;
            return false;
        }

        ICommand _sortGamesWonCommand;

        public ICommand SortGamesWonCommand
        {
            get
            {
                return _sortGamesWonCommand ?? (_sortGamesWonCommand =
                           new RelayCommand(SortByGamesWonCommand, SortByGamesWonCommand_CanExecute));
            }
        }

        public void SortByGamesWonCommand()
        {
            List<PlayerModel> sortedList = _players.OrderByDescending(o => o.GamesWon).ToList();
            List<string> tempList = new List<string>();
            for (int rank = 0; rank < 10; rank++)
                tempList.Add(string.Format("{0} {1} {2}", rank + 1, sortedList[rank].Name, sortedList[rank].GamesWon));
            DisplayPlayers = tempList;
            LastSort = "Games won";
        }

        public bool SortByGamesWonCommand_CanExecute()
        {
            if (_players.Count > 0)
                return true;
            return false;
        }

        ICommand _sortPointsCommand;

        public ICommand SortPointsCommand
        {
            get
            {
                return _sortPointsCommand ?? (_sortPointsCommand =
                           new RelayCommand(SortByPointsCommand, SortByPointsCommand_CanExecute));
            }
        }

        public void SortByPointsCommand()
        {
            List<PlayerModel> sortedList = _players.OrderByDescending(o => o.Points).ToList();
            List<string> tempList = new List<string>();
            for (int rank = 0; rank < 10; rank++)
                tempList.Add(string.Format("{0} {1} {2}", rank + 1, sortedList[rank].Name, sortedList[rank].Points));
            DisplayPlayers = tempList;
            LastSort = "Points";
        }

        public bool SortByPointsCommand_CanExecute()
        {
            if (_players.Count > 0)
                return true;
            else
            {
                return false;
            }
        }

        ICommand _searchPlayerCommand;
        public ICommand SearchPlayerCommand
        {
            get
            {
                return _searchPlayerCommand ?? (_searchPlayerCommand =
                           new RelayCommand<string>(SearchForPlayerCommand));
            }
        }

        public void SearchForPlayerCommand(string nameToSearchFor)
        {
            if (nameToSearchFor == "")
            {
                MessageBox.Show("You must enter a name!", "Unable to find player",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                int i;
                for (i = 0; i < _players.Count; i++)
                {
                    if (nameToSearchFor.Equals(_players[i].Name, StringComparison.Ordinal))
                        break;
                }

                if (-1 < i && i < _players.Count)
                {
                    FoundName = _players[i].Name;
                    FoundKills = _players[i].Kills;
                    FoundDeaths = _players[i].Deaths;
                    FoundGamesPlayed = _players[i].GamesPlayed;
                    FoundGamesWon = _players[i].SettingGamesWon();
                    FoundPoints = _players[i].SettingPoints();
                }
                else
                {
                    FoundName = "Name not found!";
                    FoundKills = 0;
                    FoundDeaths = 0;
                    FoundGamesPlayed = 0;
                    FoundGamesWon = 0;
                    FoundPoints = 0;
                }
            }
        }

        ICommand _generatePlayerDatabase;

        public ICommand GeneratePlayerDatabase
        {
            get
            {
                return _generatePlayerDatabase ??
                       (_generatePlayerDatabase = new RelayCommand(GeneratePlayerDatabaseCommand));
            }
        }

        public void GeneratePlayerDatabaseCommand()
        {
            _players.Clear();
            _players.Add(new PlayerModel("Nickolai", 10, 2, 5));
            _players.Add(new PlayerModel("Rune", 11, 2, 5));
            _players.Add(new PlayerModel("Armina", 27, 5, 8));
            _players.Add(new PlayerModel("Emma", 14, 14, 14));
            _players.Add(new PlayerModel("Parweiz", 23, 10, 17));
            _players.Add(new PlayerModel("Simon", 11, 7, 9));
            _players.Add(new PlayerModel("Tobias", 15, 5, 7));
            _players.Add(new PlayerModel("Susanne", 23, 10, 12));
            _players.Add(new PlayerModel("Poul Eijnar", 14, 10, 12));
            _players.Add(new PlayerModel("Lars Mortensen", 9, 1, 4));
            _players.Add(new PlayerModel("Bossen", 37, 21, 29));
            _players.Add(new PlayerModel("Bumsen", 2, 19, 19));
            _players.Add(new PlayerModel("Anders", 21, 14, 17));
            _players.Add(new PlayerModel("Lasse", 17, 9, 11));
            _players.Add(new PlayerModel("Uffe", 28, 20, 22));
            _players.Add(new PlayerModel("Signe", 9, 9, 9));
            _players.Add(new PlayerModel("Troels", 30, 23, 24));
            _players.Add(new PlayerModel("Mike", 5, 15, 15));
            _players.Add(new PlayerModel("Camilla", 12, 19, 20));
            _players.Add(new PlayerModel("Frederik", 20, 17, 17));
            _players.Add(new PlayerModel("Tina", 1, 1, 1));
            _players.Add(new PlayerModel("Letsgo", 3, 7, 7));
            _players.Add(new PlayerModel("Miriam", 7, 8, 8));
            _players.Add(new PlayerModel("Tim", 13, 13, 13));
            _players.Add(new PlayerModel("Anne", 36, 3, 9));
        }


        #endregion

        #region Properties

        public string FoundName
        {
            get { return _playerModel.Name; }
            set
            {
                if (value != _playerModel.Name)
                {
                    _playerModel.Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int FoundKills
        {
            get { return _playerModel.Kills; }
            set
            {
                if (value != _playerModel.Kills)
                {
                    _playerModel.Kills = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int FoundDeaths
        {
            get { return _playerModel.Deaths; }
            set
            {
                if (value != _playerModel.Deaths)
                {
                    _playerModel.Deaths = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int FoundGamesPlayed
        {
            get { return _playerModel.GamesPlayed; }
            set
            {
                if (value != _playerModel.GamesPlayed)
                {
                    _playerModel.GamesPlayed = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int FoundGamesWon
        {
            get { return _playerModel.GamesWon; }
            set
            {
                if (value != _playerModel.GamesWon)
                {
                    _playerModel.GamesWon = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int FoundPoints
        {
            get { return _playerModel.Points; }
            set
            {
                if (value != _playerModel.Points)
                {
                    _playerModel.Points = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string LastSort
        {
            get { return _lastSort; }
            set
            {
                if (value != _lastSort)
                {
                    _lastSort = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public List<string> DisplayPlayers
        {
            get { return _displayPlayers; }
            set
            {
                if (value != _displayPlayers)
                {
                    _displayPlayers = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
        }

        #endregion

        #region INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    #endregion
}
