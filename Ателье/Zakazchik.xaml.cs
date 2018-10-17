﻿using System;
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
	/// Логика взаимодействия для Zakazchik.xaml
	/// </summary>
	public partial class Zakazchik : Window
	{
		public Zakazchik()
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
			Constructor constructor = new Constructor();
			constructor.Show();
			this.Hide();
		}
	}
}
