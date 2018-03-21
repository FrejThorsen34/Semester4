using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAssignmentImproved
{
    class SoundsModel
    {
        private double _musicVolume;
        private double _soundVolume;

        public SoundsModel()
        {
        }

        public SoundsModel(double musicVolume, double soundVolume)
        {
            //Settting properties
            MusicVolume = musicVolume;
            SoundVolume = soundVolume;
        }

        public double MusicVolume
        {
            get { return _musicVolume; }
            set { _musicVolume = value; }
        }

        public double SoundVolume
        {
            get { return _soundVolume; }
            set { _soundVolume = value; }
        }
    }
}
