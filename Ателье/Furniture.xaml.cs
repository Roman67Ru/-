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
    /// Логика взаимодействия для Furniture.xaml
    /// </summary>
    public partial class Furniture : Window
    {
		АтельеEntities db;

        public Furniture()
        {
            InitializeComponent();
        }

		private void Window_Closed(object sender, EventArgs e)
		{
			storekeeper storekeeper = new storekeeper();
			storekeeper.Show();
			this.Hide();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			db = new АтельеEntities();
			BDGrid.ItemsSource = db.Склад_фурнитуры.Join(db.Фурнитура, x=> x.Артикул_фурнитуры, p=>p.Артикул_фурнитуры, (x,p) => new {p.Артикул_фурнитуры, p.Тип, p.Название, p.Вес, p.Длинна, p.Ширина, p.Цена, x.Количиство }).ToList();
		}
	}
}
