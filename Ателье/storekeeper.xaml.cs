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
using System.Windows.Shapes;

namespace Ателье
{
	/// <summary>
	/// Логика взаимодействия для storekeeper.xaml
	/// </summary>
	public partial class storekeeper : Window
	{
		public storekeeper()
		{
			InitializeComponent();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Hide();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Tkani tkani = new Tkani();
			tkani.Show();
			this.Hide();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Furniture furniture = new Furniture();
			furniture.Show();
			this.Hide();
		}
	}
}
