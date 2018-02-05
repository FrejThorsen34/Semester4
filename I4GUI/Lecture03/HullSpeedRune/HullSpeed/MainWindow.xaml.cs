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

namespace HullSpeed
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		SailBoat boat;

		public MainWindow()
		{
			InitializeComponent();
			boat = new SailBoat();
			Loaded += new RoutedEventHandler(MainWindow_Loaded);
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			Keyboard.Focus(tbxName);
		}

		private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
		{
			boat.Name = tbxName.Text;
		}

		private void tbxLength_TextChanged(object sender, TextChangedEventArgs e)
		{
			boat.Length = Double.Parse(tbxLength.Text);
		}

		private void btnCalculateHullSpeed_Click(object sender, RoutedEventArgs e)
		{
			tbxHullSpeed.Text = boat.Hullspeed().ToString("F2");
		}
	}
}
