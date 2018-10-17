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
	/// Логика взаимодействия для Product.xaml
	/// </summary>
	public partial class Product : Window
	{
		АтельеEntities db;
		public Product()
		{
			InitializeComponent();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Manager manager = new Manager();
			manager.Show();
			this.Hide();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			db = new АтельеEntities();
			DBGrid.ItemsSource = db.Заказать_продукт.Join(db.Продукт, t => t.Артикул_продукта, x => x.Артикул_продукта, (t, x) => new { Артикул = t.Артикул_продукта, t.Количество, x.Название }).ToList();

		}

		private void DBGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		//	string art = DBGrid.rows
			
			//var prod = db.Продукт.FirstOrDefault(x=>x.Артикул_продукта == art);
			//img.Source = new BitmapImage(new Uri(prod.Картинка));
			//MessageBox.Show(art);
		}
	}
}
