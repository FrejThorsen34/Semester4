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

namespace HullSpeed2Nickolai_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sailboat boat;
        public MainWindow()
        {
            InitializeComponent();
            boat = new Sailboat();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(tbxName);
        }

        private void tbxLength_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxLength.Text.Trim() != "")
                try
                {
                    boat.Length = Double.Parse(tbxLength.Text);
                }
                catch
                {
                    MessageBox.Show("The length must be numbers!");
                }

        }
        private void tbxName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            boat.Name = tbxName.Text;
        }

        private void BtnCalculateHullSpeed_OnClick(object sender, RoutedEventArgs e)
        {
            tbxHullSpeed.Text = boat.Hullspeed().ToString("F1");
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.L:
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        FontSize += 2;
                        e.Handled = true;
                    }
                    break;
                case Key.S:
                    if ((Keyboard.Modifiers == ModifierKeys.Control) && FontSize >= 6)
                    {
                        FontSize -= 2;
                        e.Handled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"The name of the boat is {boat.Name}!");
        }
    }
}
