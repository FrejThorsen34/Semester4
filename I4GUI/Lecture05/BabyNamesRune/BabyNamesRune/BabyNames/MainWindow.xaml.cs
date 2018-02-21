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

namespace BabyNames
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
			Loaded += new RoutedEventHandler(MainWindow_Loaded);
			lstDecade.SelectionChanged += new SelectionChangedEventHandler(lstDecade_SelectionChanged);
			btnSearch.Click += new RoutedEventHandler(Search);
		}

		private void Search(object sender, RoutedEventArgs e)
		{
			string name = tbxName.Text;

		}

		private void lstDecade_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListBoxItem item;

			item = lstDecade.SelectedItem as ListBoxItem;
			if (item != null)
			{
				int decade = (Convert.ToInt32(item.Content) - 1900) / 10;
				lstTopBabyNames.Items.Clear();
				for (int i=1; i < 11; i++)
				{
					lstTopBabyNames.Items.Add(string.Format("{0,2} {1}", i, _rankMatrix[decade, i - 1]));
				}
			}
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			string file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "babynames.txt");
			this._namesCollection = LoadData.ReadBabyNameData(file);

			foreach (BabyName name in _namesCollection)
			{
				for (int decade = 1900; decade < 2010; decade += 10)
				{
					int rank = name.Rank(decade);
					int decadeIndex = (decade - 1900) / 10;
					if(rank>0 && rank<11)
						if (_rankMatrix[decadeIndex, rank - 1] == null)
						{
							_rankMatrix[decadeIndex, rank - 1] = name.Name;
						}
						else
						{
							_rankMatrix[decadeIndex, rank-1] += " and " + name.Name;
						}

				}
			}
		}
	}
}
