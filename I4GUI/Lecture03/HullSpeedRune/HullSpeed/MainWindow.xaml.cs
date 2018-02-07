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
			PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
			//MouseLeftButtonDown += new MouseButtonEventHandler(Image_MouseLeftButtonDown);
		}

		private void Image_MouseLeftButtonDown(object sender, MouseEventArgs e)
		{
			MessageBox.Show($"The name of the ship is {boat.Name}");
		}

		private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.L)
			{
				if (Keyboard.Modifiers == ModifierKeys.Control)
				{
					FontSize += 2;
					e.Handled = true;
				}
			}

			if (e.Key == Key.S)
			{
				if (Keyboard.Modifiers == ModifierKeys.Control && FontSize >= 4)
				{
					FontSize -= 2;
					e.Handled = true;
				}
			}
			
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
			if (tbxLength.Text.Trim() != "")
				try
				{
					boat.Length = Double.Parse(tbxLength.Text);
				}
				catch
				{
					MessageBox.Show("The length field must only contaion numbers");
				}
		}

		private void btnCalculateHullSpeed_Click(object sender, RoutedEventArgs e)
		{
			tbxHullSpeed.Text = boat.Hullspeed().ToString("F2");
		}
	}
}
