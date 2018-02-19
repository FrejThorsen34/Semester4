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
		private string[,] _rankMatrix = new string[10, 10];

		public MainWindow()
		{
			InitializeComponent();
			Loaded += new RoutedEventHandler(MainWindow_Loaded);
			lstDecade.SelectionChanged += new SelectionChangedEventHandler(lstDecade_SelectionChanged);
		}

		private void lstDecade_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListBoxItem item = lstDecade.SelectedItem as ListBoxItem;
			if (item != null)
			{
				int deade = (Convert.ToInt32(item.Content) - 1900) / 10;
				
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
							_rankMatrix[decadeIndex, rank-1] += "and" + name.Name;
						}

				}
			}
		}
	}
}
