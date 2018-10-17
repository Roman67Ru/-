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
	/// Логика взаимодействия для Tkani.xaml
	/// </summary>
	public partial class Tkani : Window
	{
		АтельеEntities db;
		public Tkani()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			db = new АтельеEntities();
		    DBGrid.ItemsSource = db.Ткань.Join(db.Склад_ткани, t => t.Артикул_ткани, x => x.Артикул_ткани, (t, x) => new { Артикул = t.Артикул_ткани,  t.Цена, t.Название, x.Длинна, x.Ширина, Стоимость =  t.Цена * (x.Длинна / 100) * (x.Ширина / 100)}).ToList();
			var s = db.Ткань.Join(db.Склад_ткани, t => t.Артикул_ткани, x => x.Артикул_ткани, (t, x) => new { Стоимость = t.Цена * ((x.Длинна / 100) * (x.Ширина / 100)) });
			var sum = s.Sum(n => n.Стоимость);
			Itog.Text = "Итого на складе находится ткани на общую сумму: "+ Convert.ToString(decimal.Round((decimal)sum,2))+"р.";
			DBGrid1.ItemsSource = (from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани where (Склад_ткани.Длинна  * Склад_ткани.Ширина) <= 300 select new {Артикул = Ткань.Артикул_ткани, Ткань.Цена, Склад_ткани.Длинна, Склад_ткани.Ширина, Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100)* (Склад_ткани.Ширина / 100)}).ToList();
			var ss = from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани where (Склад_ткани.Длинна * Склад_ткани.Ширина) <= 300 select new { Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100) * (Склад_ткани.Ширина / 100) };
			var summ = ss.Sum(n => n.Стоимость);
			Itog1.Text = Itog1.Text + " " + Convert.ToString(decimal.Round((decimal)summ, 2)) + "р.";
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			storekeeper storekeeper = new storekeeper();
			storekeeper.Show();
			this.Hide();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int param = Convert.ToInt32(Convert.ToDecimal(Param.Text) * 1000);
				DBGrid1.ItemsSource = (from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани where (Склад_ткани.Длинна * Склад_ткани.Ширина) <= param select new { Артикул = Ткань.Артикул_ткани, Ткань.Цена, Склад_ткани.Длинна, Склад_ткани.Ширина, Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100) * (Склад_ткани.Ширина / 100) }).ToList();
				var ss = from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани where (Склад_ткани.Длинна * Склад_ткани.Ширина) <= param select new { Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100) * (Склад_ткани.Ширина / 100) };
				var summ = ss.Sum(n => n.Стоимость);
				Itog1.Text = "Из этого на списание " + Convert.ToString(decimal.Round((decimal)summ, 2)) + "р.";
			}
			catch (Exception ex) { MessageBox.Show("Данные введены не корректно!"); }
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (comb.SelectedIndex == 1)
			{
				var qw = from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани select new { Артикул = Ткань.Артикул_ткани, Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100) * (Склад_ткани.Ширина / 100) };

				DBGrid.ItemsSource = qw.GroupBy(c => c.Артикул).Select(g => new { Рулон = g.Key, Количество = g.Count(), Стоимость = g.Sum(t => t.Стоимость) }).ToList();
				var s = db.Ткань.Join(db.Склад_ткани, t => t.Артикул_ткани, x => x.Артикул_ткани, (t, x) => new { Стоимость = t.Цена * ((x.Длинна / 100) * (x.Ширина / 100)) });
				var sum = s.Sum(n => n.Стоимость);
				Itog.Text = "Итого на складе находится ткани на общую сумму: " + Convert.ToString(decimal.Round((decimal)sum, 2)) + "р.";
				DBGrid1.ItemsSource = (from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани where (Склад_ткани.Длинна * Склад_ткани.Ширина) <= 300 select new { Артикул = Ткань.Артикул_ткани, Ткань.Цена, Склад_ткани.Длинна, Склад_ткани.Ширина, Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100) * (Склад_ткани.Ширина / 100) }).ToList();
				var ss = from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани where (Склад_ткани.Длинна * Склад_ткани.Ширина) <= 300 select new { Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100) * (Склад_ткани.Ширина / 100) };
				var summ = ss.Sum(n => n.Стоимость);
				Itog1.Text = "Из этого на списание " + Convert.ToString(decimal.Round((decimal)summ, 2)) + "р.";
			}
			else {
				DBGrid.ItemsSource = db.Ткань.Join(db.Склад_ткани, t => t.Артикул_ткани, x => x.Артикул_ткани, (t, x) => new { Артикул = t.Артикул_ткани, t.Цена, t.Название, x.Длинна, x.Ширина, Стоимость = t.Цена * (x.Длинна / 100) * (x.Ширина / 100) }).ToList();
				var s = db.Ткань.Join(db.Склад_ткани, t => t.Артикул_ткани, x => x.Артикул_ткани, (t, x) => new { Стоимость = t.Цена * ((x.Длинна / 100) * (x.Ширина / 100)) });
				var sum = s.Sum(n => n.Стоимость);
				Itog.Text = "Итого на складе находится ткани на общую сумму: " + Convert.ToString(decimal.Round((decimal)sum, 2)) + "р.";
				DBGrid1.ItemsSource = (from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани where (Склад_ткани.Длинна * Склад_ткани.Ширина) <= 300 select new { Артикул = Ткань.Артикул_ткани, Ткань.Цена, Склад_ткани.Длинна, Склад_ткани.Ширина, Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100) * (Склад_ткани.Ширина / 100) }).ToList();
				var ss = from Ткань in db.Ткань join Склад_ткани in db.Склад_ткани on Ткань.Артикул_ткани equals Склад_ткани.Артикул_ткани where (Склад_ткани.Длинна * Склад_ткани.Ширина) <= 300 select new { Стоимость = Ткань.Цена * (Склад_ткани.Длинна / 100) * (Склад_ткани.Ширина / 100) };
				var summ = ss.Sum(n => n.Стоимость);
				Itog1.Text = "Из этого на списание " + Convert.ToString(decimal.Round((decimal)summ, 2)) + "р.";
			}
		}
	}
}
