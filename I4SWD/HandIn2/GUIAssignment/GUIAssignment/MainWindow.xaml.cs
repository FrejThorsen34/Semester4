using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GUIAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Player> _players;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bool fileFound = true;
            string file;
            file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "playernames.txt");
            try
            {
                Players._players = Utility.ReadPlayerData(file);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "An error occured in GUI Assignment: ");
                Application.Current.Shutdown();
                fileFound = false;
            }
        }
    }
}
