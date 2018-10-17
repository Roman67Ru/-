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

namespace Ателье
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		АтельеEntities db;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			db = new АтельеEntities();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string role = db.Пользователи.Where(x => x.Логин == Login.Text && x.Пароль == Password.Password).First().Роль;
				switch (role)
				{
					case "client":
						Zakazchik zakazchik = new Zakazchik();
						zakazchik.Show();
						this.Hide();
						break;
					case "manager":
						Manager manager = new Manager();
						manager.Show();
						this.Hide();
						break;
					case "storekeeper":
						storekeeper storekeeper = new storekeeper();
						storekeeper.Show();
						this.Hide();
						break;
					case "direktor":
						Director director = new Director();
						director.Show();
						this.Hide();
						break;
					default:
						MessageBox.Show("Непредвиденная ошибка!");
						break;
				}
			}
			catch (Exception ex) { MessageBox.Show("В доступе отказано!"); }
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Registration registration = new Registration();
			registration.Show();
			this.Hide();
		}
	}
}
