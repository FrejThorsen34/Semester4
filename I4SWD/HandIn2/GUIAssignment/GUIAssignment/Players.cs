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
    public class Players : ObservableCollection<Player>, INotifyPropertyChanged
    {
        public static List<Player> _players;
        Player _playerModel = new Player();
        public Players()
        {
            if ((bool) (DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                Add(new Player("Nickolai 10 2 5"));
                Add(new Player("Rune 11 2 5"));
                Add(new Player("Armina 27 5 8"));
                Add(new Player("Emma 14 14 14"));
                Add(new Player("Parweiz 23 10 17"));
                Add(new Player("Simon 11 7 9"));
                Add(new Player("Tobias 15 5 7"));
                Add(new Player("Susanne 23 10 12"));
                Add(new Player("Poul Eijnar 14 10 12"));
                Add(new Player("Lars Mortensen 9 1 4"));
            }
        }

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
        }

        public bool SortByKills_CanExecute()
        {
            return true;
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
        }

        public bool SortByDeaths_CanExecute()
        {
            return true;
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
        }

        public bool SortByGamesPlayedCommand_CanExecute()
        {
            return true;
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
        }

        public bool SortByGamesWonCommand_CanExecute()
        {
            return true;
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
        }

        public bool SortByPointsCommand_CanExecute()
        {
            return true;
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

        public void SearchForPlayerCommand(string playerName)
        {
            int i;
            for (i = 0; i < _players.Count; i++)
            {
                if (_players[i].Name == playerName)
                    break;
            }

            if (-1 < i && i < _players.Count)
            {
                _playerModel = _players[i];
                _playerModel.Name = _players[i].Name;
                _playerModel.Kills = _players[i].Kills;
                _playerModel.Deaths = _players[i].Deaths;
                _playerModel.GamesPlayed = _players[i].Deaths;
            }
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

        public uint FoundKills
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

        public uint FoundDeaths
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

        public uint FoundGamesPlayed
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

        public uint FoundGamesWon
        {
            get { return _playerModel.GamesWon; }
        }

        public double FoundPoints
        {
            get { return _playerModel.Points; }
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
