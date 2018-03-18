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

// ========== Authors ==========  //
// Gruppe 25 SWD: GUI Assignment  //
// Nickolai Lundby Ernst, NE84070 //
// Rune Keenaa Aagaard, 20105809  //
// =============================  //

namespace GUIAssignmentImproved
{
    public class GraphicsViewModel : IPageViewModel, INotifyPropertyChanged
    {
        public string Name
        {
            get { return "Graphics"; }
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
