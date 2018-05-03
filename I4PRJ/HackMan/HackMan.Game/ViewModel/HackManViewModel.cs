using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        public HackPlayer HackPlayer
        {
            get { return _model.HackPlayer; }
            set
            {
                if (value != _model.HackPlayer)
                {
                    _model.HackPlayer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //public int Bitcoins
        //{
        //    get { return _model.HackPlayer.Bitcoins; }
        //    set
        //    {
        //        if (value != _model.HackPlayer.Bitcoins)
        //        {
        //            _model.HackPlayer.Bitcoins = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}

        //public int Laptops
        //{
        //    get { return _model.HackPlayer.Laptops; }
        //    set
        //    {
        //        if (value != _model.HackPlayer.Laptops)
        //        {
        //            _model.HackPlayer.Laptops = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}

        //public int HackPower
        //{
        //    get { return _model.HackPlayer.HackPower; }
        //    set
        //    {
        //        if (value != _model.HackPlayer.HackPower)
        //        {
        //            _model.HackPlayer.HackPower = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}

        #endregion                

        #region Commands

        public void HackManStepUp()
        {
            _model.MoveHacker(Direction.up);
        }

        public bool HackManStepUp_CanExecute()
        {
            return _model.CanStep(Direction.up);            
        }

        public void HackManStepDown()
        {
            _model.MoveHacker(Direction.down);
        }

        public bool HackManStepDown_CanExecute()
        {
            return _model.CanStep(Direction.down);
        }

        public void HackManStepRight()
        {
            _model.MoveHacker(Direction.right);
        }

        public bool HackManStepRight_CanExecute()
        {
            return _model.CanStep(Direction.right);
        }

        public void HackManStepLeft()
        {
            _model.MoveHacker(Direction.left);
        }

        public bool HackManStepLeft_CanExecute()
        {
            return _model.CanStep(Direction.left);
        }

        public void HackManBuyPower()
        {
            _model.BuyPower(Powerup.power);
        }

        public bool HackManBuyPower_CanExecute()
        {
            return _model.CanBuy(Powerup.power);
        }

        public void HackManBuyLaptop()
        {
            _model.BuyPower(Powerup.laptop);
        }

        public bool HackManBuyLaptop_CanExecute()
        {
            return _model.CanBuy(Powerup.laptop);
        }

        public void HackManPlaceLaptop()
        {
            Debug.WriteLine("HackManPlaceLaptop was called in HackManViewModel");
            _model.PlaceLaptop();
        }

        public bool HackManPlaceLaptop_CanExecute()
        {
            Debug.WriteLine("HackManPlaceLaptop_CanExecute was called in HackManViewModel");
            return _model.CanPlace();
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
