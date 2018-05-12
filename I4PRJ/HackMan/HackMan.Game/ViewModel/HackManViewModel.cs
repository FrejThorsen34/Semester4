using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

        private IPAddress _ipAddress = IPAddress.Parse("192.168.1.61");
        private Client _client;
        private HackManModel _model;
        ICommand _hackManStepUpCommand;
        ICommand _hackManStepDownCommand;
        ICommand _hackManStepRightCommand;
        ICommand _hackManStepLeftCommand;
        ICommand _hackManBuyLaptopLengthCommand;
        ICommand _hackManBuyLaptopCommand;
        ICommand _hackManPlaceLaptopCommand;

        #endregion

        public HackManViewModel()
        {
            _client = new Client(_ipAddress);
            _model = new HackManModel(_client);
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

        public ICommand HackManBuyLaptopLengthCommand
        {
            get
            {
                return _hackManBuyLaptopLengthCommand ?? (_hackManBuyLaptopLengthCommand =
                           new RelayCommand(HackManBuyLaptopLength, HackManBuyLaptopLength_CanExecute));
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
            get { return _model.GameBoard; }
            set
            {
                if (value != _model.GameBoard)
                {
                    _model.GameBoard = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<SidePanelItem> PowerUps
        {
            get { return _model.PowerUps; }
            set
            {
                if (value != _model.PowerUps)
                {
                    _model.PowerUps = value;
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
            return _model.CanStep("moveup");
        }

        public void HackManStepDown()
        {
            _model.MoveHacker(Direction.down);
        }

        public bool HackManStepDown_CanExecute()
        {
            return _model.CanStep("movedown");
        }

        public void HackManStepRight()
        {
            _model.MoveHacker(Direction.right);
        }

        public bool HackManStepRight_CanExecute()
        {
            return _model.CanStep("moveright");
        }

        public void HackManStepLeft()
        {
            _model.MoveHacker(Direction.left);
        }

        public bool HackManStepLeft_CanExecute()
        {
            return _model.CanStep("moveleft");
        }

        public void HackManBuyLaptopLength()
        {
            _model.BuyLaptopLength();
        }

        public bool HackManBuyLaptopLength_CanExecute()
        {
            return _model.CanBuy(Powerup.laptoplength);
        }

        public void HackManBuyLaptop()
        {
            _model.BuyLaptop();
        }

        public bool HackManBuyLaptop_CanExecute()
        {
            return _model.CanBuy(Powerup.laptop);
        }

        public void HackManPlaceLaptop()
        {
            _model.PlaceLaptop();
        }

        public bool HackManPlaceLaptop_CanExecute()
        {
            return _model.CanPlaceLaptop();
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
