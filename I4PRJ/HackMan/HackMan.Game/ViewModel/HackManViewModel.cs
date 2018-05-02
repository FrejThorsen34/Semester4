using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmFoundation.Wpf;

namespace HackMan.Game
{
    public class HackManViewModel : ObservableCollection<HackManModel>, INotifyPropertyChanged
    {
        #region Variables

        private HackManModel _model;
        private ObservableCollection<GameField> _gameBoard;
        private String _testImage = "/HackMan.Game;component/ViewModel/HackManResources/hackman.png";
        ICommand _hackManStepUpCommand;
        ICommand _hackManStepDownCommand;
        ICommand _hackManStepRightCommand;
        ICommand _hackManStepLeftCommand;
        ICommand _hackManBuyPowerCommand;
        ICommand _hackManBuyLaptopCommand;
        ICommand _hackManPlaceLaptopCommand;

        #endregion

        public HackManViewModel()
        {
            _model = new HackManModel();
            _gameBoard = new ObservableCollection<GameField>();
            GenerateGameBoard();
        }        

        #region Properties

        public ICommand HackManStepUpCommand
        {
            get
            {
                return _hackManStepUpCommand ?? (_hackManStepUpCommand =
                           new RelayCommand(HackManStepUp, HackManStepUp_CanExecute));
            }
        }

        public ICommand HackManStepDownCommand
        {
            get
            {
                return _hackManStepDownCommand ?? (_hackManStepDownCommand =
                           new RelayCommand(HackManStepDown, HackManStepDown_CanExecute));
            }
        }

        public ICommand HackManStepLeftCommand
        {
            get
            {
                return _hackManStepLeftCommand ?? (_hackManStepLeftCommand =
                           new RelayCommand(HackManStepLeft, HackManStepLeft_CanExecute));
            }
        }

        public ICommand HackManStepRightCommand
        {
            get
            {
                return _hackManStepRightCommand ?? (_hackManStepRightCommand =
                           new RelayCommand(HackManStepRight, HackManStepRight_CanExecute));
            }
        }

        public ICommand HackManBuyPowerCommand
        {
            get
            {
                return _hackManBuyPowerCommand ?? (_hackManBuyPowerCommand =
                           new RelayCommand(HackManBuyPower, HackManBuyPower_CanExecute));
            }
        }

        public ICommand HackManBuyLaptopCommand
        {
            get
            {
                return _hackManBuyLaptopCommand ?? (_hackManBuyLaptopCommand =
                           new RelayCommand(HackManBuyLaptop, HackManBuyLaptop_CanExecute));
            }
        }

        public ICommand HackManPlaceLaptopCommand
        {
            get
            {
                return _hackManPlaceLaptopCommand ?? (_hackManPlaceLaptopCommand =
                           new RelayCommand(HackManPlaceLaptop, HackManPlaceLaptop_CanExecute));
            }
        }

        public ObservableCollection<GameField> GameBoard
        {
            get { return _gameBoard; }
            set
            {
                if (value != _gameBoard)
                {
                    _gameBoard = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String TestImage
        {
            get { return _testImage; }
            set
            {
                if (value != _testImage)
                {
                    _testImage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion                

        #region Commands

        public void HackManStepUp()
        {
            _model.MoveHacker(Direction.up);
        }

        public bool HackManStepUp_CanExecute()
        {
            return true;
        }

        public void HackManStepDown()
        {
            _model.MoveHacker(Direction.down);
        }

        public bool HackManStepDown_CanExecute()
        {
            return true;
        }

        public void HackManStepRight()
        {
            _model.MoveHacker(Direction.right);
        }

        public bool HackManStepRight_CanExecute()
        {
            return true;
        }

        public void HackManStepLeft()
        {
            _model.MoveHacker(Direction.left);
        }

        public bool HackManStepLeft_CanExecute()
        {
            return true;
        }

        public void HackManBuyPower()
        {
            _model.BuyPower(Powerup.power);
        }

        public bool HackManBuyPower_CanExecute()
        {
            return true;
        }

        public void HackManBuyLaptop()
        {
            _model.BuyPower(Powerup.laptop);
        }

        public bool HackManBuyLaptop_CanExecute()
        {
            return true;
        }

        public void HackManPlaceLaptop()
        {
            _model.PlaceLaptop();
        }

        public bool HackManPlaceLaptop_CanExecute()
        {
            return true;
        }

        public void GenerateGameBoard()
        {
            String level = Properties.Resources.Level;
            String[] gameBoard = level.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int rowCounter = 0;
            int listCounter = 0;
            foreach (String row in gameBoard)
            {
                String[] columns = row.Split(' ');
                for (int columnCounter = 0; columnCounter < 14; columnCounter++)
                {
                    switch (columns[columnCounter])
                    {
                        case "HM":
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.hacker);
                            break;
                        case "FW":
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.firewall);
                            break;
                        case "EP":
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.empty);
                            break;
                        case "UB":
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.unbreakable);
                            break;
                        default:
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.empty);
                            break;
                    }
                    rowCounter++;
                    listCounter++;
                }
            }
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

        #endregion
    }
}
