using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestLoadAnimation
{
	/// <summary>
	/// Interaction logic for ParentWindow.xaml
	/// </summary>
	public partial class ParentWindow : Window
	{
		public ParentWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.ShowDialog();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("lol");
		}
	}
}
