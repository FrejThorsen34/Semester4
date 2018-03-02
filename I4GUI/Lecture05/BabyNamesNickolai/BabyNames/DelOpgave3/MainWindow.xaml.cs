using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIO = System.IO;

namespace DelOpgave3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BabyName> _namesCollection;
        private string[,] _rankMatrix = new string[11, 10];
        public MainWindow()
        {
            InitializeComponent();
            for (int decade = 1900; decade < 2010; decade += 10)
                IstDecade.Items.Add(decade);

            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            IstDecade.SelectionChanged += new SelectionChangedEventHandler(IstDecade_SelectionChanged);
            btnSearch.Click += new RoutedEventHandler(Search);
        }

        void Search(object sender, RoutedEventArgs e)
        {
            string name = tbxName.Text;
            
            int i;
            for (i = 0; i < _namesCollection.Count; i++)
            {
                if (_namesCollection[i].Name == name)
                    break;
            }

            if (-1 < i && i < _namesCollection.Count)
            {
                tblkError.Text = "";
                BabyName theName = _namesCollection[i];
                tboxAveRank.Text = theName.AverageRank().ToString();
                if (theName.Trend() > 0)
                    tboxTrend.Text = "More popular";
                else if (theName.Trend() == 0)
                    tboxTrend.Text = "Inconclusive";
                else
                    tboxTrend.Text = "Less popular";

                int rank;
                IstNameRanking.Items.Clear();
                for (int year = 1900; year < 2001; year += 10)
                {
                    rank = theName.Rank(year);
                    IstNameRanking.Items.Add(string.Format("{0:####}    {1:####}", year, rank));
                }
            }
            else
            {
                tblkError.Text = "Name not found!";
                tboxAveRank.Text = "";
                tboxTrend.Text = "";
                IstNameRanking.Items.Clear();
            }
        }

        void IstDecade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int decade = (int) IstDecade.SelectedItem;
            decade = (decade - 1900) / 10;
            IstTopBabyNames.Items.Clear();
            for (int i = 1; i < 11; ++i)
            {
                IstTopBabyNames.Items.Add(string.Format("{0,2} {1}", i, _rankMatrix[decade, i - 1]));
            }           
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bool fileFound = true;
            string file;
            file = SIO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "babynames.txt");
            try
            {
                this._namesCollection = Utility.ReadBabyNameData(file);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "An error occured in lab 3:");
                Application.Current.Shutdown();
                fileFound = false;
            }
            
            if(fileFound)
                foreach (BabyName name in _namesCollection)
                {
                    for (int decade = 1900; decade < 2010; decade += 10)
                    {
                        int rank = name.Rank(decade);
                        int decadeIndex = (decade - 1900) / 10;
                        if (0 < rank && rank < 11)
                            if (_rankMatrix[decadeIndex, rank - 1] == null)
                                _rankMatrix[decadeIndex, rank - 1] = name.Name;
                            else
                                _rankMatrix[decadeIndex, rank - 1] += " and " + name.Name;
                    }
                }
        }
    }
}
