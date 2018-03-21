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
using GUIAssignmentImproved;

// ========== Authors ==========  //
// Gruppe 25 SWD: GUI Assignment  //
// Nickolai Lundby Ernst, NE84070 //
// Rune Keenaa Aagaard, 20105809  //
// =============================  //

namespace GUIAssignmentImproved
{
    public class SoundsViewModel : IPageViewModel, INotifyPropertyChanged
    {
        SoundsModel _soundsModel = new SoundsModel();

        public double MVolume
        {
            get { return _soundsModel.MusicVolume; }
            set
            {
                if (_soundsModel.MusicVolume != value)
                {
                    _soundsModel.MusicVolume = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double SVolume
        {
            get { return _soundsModel.SoundVolume; }
            set
            {
                if (_soundsModel.SoundVolume != value)
                {
                    _soundsModel.SoundVolume = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Name
        {
            get { return "Sounds"; }
        }

        ICommand _musicVolumeCommand;

        public ICommand MusicVolume
        {
            get
            {
                return _musicVolumeCommand ?? (_musicVolumeCommand =
                           new RelayCommand(MusicVolumeCommand, MusicVolumeCommand_CanExecute));
            }
        }

        public void MusicVolumeCommand()
        {
            MVolume++;
        }

        public bool MusicVolumeCommand_CanExecute()
        {
            //Check om musik kan afspille lydfil
            if ()
            {
                return true;
            }
            else
                return false;

        }

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
