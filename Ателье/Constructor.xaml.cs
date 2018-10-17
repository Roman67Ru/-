using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Constructor.xaml
    /// </summary>
    public partial class Constructor : Window
    {
        public Constructor()
        {
            InitializeComponent();
        }

		private void Window_Closed(object sender, EventArgs e)
		{
			Zakazchik zakazchik = new Zakazchik();
			zakazchik.Show();
			this.Hide();
		}

		Vector relativeMousePos;
		Border draggedBorder;
		FrameworkElement draggedObject;
		Vector originalMouseOffsetFromCenter;
		Size originalSize, originalTransformedSize;
		Point originalCenterRelativeToContainer;

		enum Direction { Left, Top, Right, Bottom}
		// какую из сторон сейчас тащим
		HashSet<Direction> draggedSide = new HashSet<Direction>();



		void StartDrag(object sender, MouseButtonEventArgs e)
		{
			MouseMove -= OnDragMove;

			draggedObject = (FrameworkElement)sender;
			relativeMousePos = e.GetPosition(draggedObject) - new Point();
			draggedObject.MouseMove += OnDragMove;
			draggedObject.LostMouseCapture += OnLostCapture;
			draggedObject.MouseUp += OnMouseUp;
			Mouse.Capture(draggedObject);
		}

		void OnDragMove(object sender, MouseEventArgs e)
		{
			UpdatePosition(e);
		}



		void UpdatePosition(MouseEventArgs e)
		{
			var point = e.GetPosition(DragArena);
			var newPost = point - relativeMousePos;
			Canvas.SetLeft(draggedObject, newPost.X);
			Canvas.SetTop(draggedObject, newPost.Y);
		}

		void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			FinishDrag(sender, e);
			Mouse.Capture(null);
		}

		void OnLostCapture(object sender, MouseEventArgs e)
		{
			FinishDrag(sender, e);
		}

		void FinishDrag (object sender, MouseEventArgs e)
		{
			draggedObject.MouseMove -= OnDragMove;
			draggedObject.LostMouseCapture -= OnLostCapture;
			draggedObject.MouseUp -= OnMouseUp;
			UpdatePosition(e);
		}

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			//Запомним что мы тянем

			draggedBorder = border1 ;
			draggedObject = border1;
			// Запомним оригинальный размер
			originalSize = draggedBorder.RenderSize;
			var localCenter = new Point(draggedBorder.ActualHeight / 2,
							   draggedBorder.ActualWidth / 2);
			// неподвижная точка - центр картинки относительно её контейнера
			originalCenterRelativeToContainer = draggedBorder.TranslatePoint(localCenter, DragArena);

			var mouseOffset = GetMouseOffsetFromCenter(e);
			var transformedSize = GetTransformedSize(draggedBorder);

			// выясним, какую сторону тащим (или какИЕ сторонЫ)
			draggedSide.Clear();
			if (mouseOffset.X < 0 && -mouseOffset.X > transformedSize.Width / 2 - 5)
				draggedSide.Add(Direction.Left);
			if (mouseOffset.X > 0 && mouseOffset.X > transformedSize.Width / 2 - 5)
				draggedSide.Add(Direction.Right);
			if (mouseOffset.Y < 0 && -mouseOffset.Y > transformedSize.Height / 2 - 5)
				draggedSide.Add(Direction.Top);
			if (mouseOffset.Y > 0 && mouseOffset.Y > transformedSize.Height / 2 - 5)
				draggedSide.Add(Direction.Bottom);

			originalMouseOffsetFromCenter = mouseOffset;
			originalTransformedSize = transformedSize;

			//draggedObject.MouseMove -= OnDragMove;
			//draggedObject.LostMouseCapture -= OnLostCapture;
			//draggedObject.MouseUp -= OnMouseUp;
			//Mouse.Capture(null);
			// подпишемся на перемещение мыши
			MouseMove += OnDragMove;
			// прикрепим фокус к нам, чтобы не ушёл
			Mouse.Capture(draggedBorder);
		}

		private void Border_MouseUp(object sender, MouseButtonEventArgs e)
		{
			// отпишемся от перемещения мыши
			MouseMove -= OnDragMove;
			// обновимся в последний раз
			UpdateTransform(e);
			// отпустим фокус
			Mouse.Capture(null);
			// подчистим
			draggedSide.Clear();
			draggedBorder = null;
		}


		void UpdateTransform(MouseEventArgs e)
		{
			// подсчитаем новые расстояния до краёв
			var mouseOffset = GetMouseOffsetFromCenter(e);
			var newSize = originalTransformedSize;

			if (draggedSide.Contains(Direction.Left))
			{
				if (mouseOffset.X > 0)
					mouseOffset.X = 0;
				var diff = originalMouseOffsetFromCenter.X - mouseOffset.X;
				newSize.Width += diff * 2;
			}

			if (draggedSide.Contains(Direction.Right))
			{
				if (mouseOffset.X < 0)
					mouseOffset.X = 0;
				var diff = mouseOffset.X - originalMouseOffsetFromCenter.X;
				newSize.Width += diff * 2;
			}

			if (draggedSide.Contains(Direction.Top))
			{
				if (mouseOffset.Y > 0)
					mouseOffset.Y = 0;
				var diff = originalMouseOffsetFromCenter.Y - mouseOffset.Y;
				newSize.Height += diff * 2;
			}

			if (draggedSide.Contains(Direction.Bottom))
			{
				if (mouseOffset.Y < 0)
					mouseOffset.Y = 0;
				var diff = mouseOffset.Y - originalMouseOffsetFromCenter.Y;
				newSize.Height += diff * 2;
			}

			var transform = (ScaleTransform)draggedBorder.LayoutTransform;
			transform.ScaleX = newSize.Width / originalSize.Width;
			transform.ScaleY = newSize.Height / originalSize.Height;
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			a.Height = GridLength.Auto;
			ButtonCloseMenu.Visibility = Visibility.Collapsed;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Collapsed;
			ButtonOpenMenu1.Visibility = Visibility.Collapsed;
			ButtonOpenMenu2.Visibility = Visibility.Collapsed;
			ButtonOpenMenu3.Visibility = Visibility.Collapsed;
			ButtonCloseMenu.Visibility = Visibility.Visible;
			string directory = @"C:\Users\User\Desktop\WPF\Ателье\Ателье\bin\Debug\images\Изделия";
foreach (var file in Directory.GetFiles(directory).Where(f => f.EndsWith(".JPG") || f.EndsWith(".jpg")))
			{
				list.Items.Add(file);
			}
		}

		private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Visible;
			ButtonOpenMenu1.Visibility = Visibility.Visible;
			ButtonOpenMenu2.Visibility = Visibility.Visible;
			ButtonOpenMenu3.Visibility = Visibility.Visible;
			ButtonCloseMenu.Visibility = Visibility.Collapsed;
			list.Items.Clear();
		}

		Size GetTransformedSize(FrameworkElement fe)
		{
			var t = fe.LayoutTransform;
			var topleft = t.Transform(new Point());
			var bottomright = t.Transform(new Point(fe.ActualWidth, fe.ActualHeight));
			return new Size(bottomright.X - topleft.X, bottomright.Y - topleft.Y);
		}

		Vector GetMouseOffsetFromCenter(MouseEventArgs e)
		{
			var positionRelativeToContainer = e.GetPosition(DragArena);
			return positionRelativeToContainer - originalCenterRelativeToContainer;
		}

		private void Image_MouseMove(object sender, MouseEventArgs e)
		{
			Image image = e.Source as Image;
			DataObject data = new DataObject(typeof(ImageSource), image.Source);
			DragDrop.DoDragDrop(image, data, DragDropEffects.Copy);
		}

		private void DragImage(object sender, MouseButtonEventArgs e)
		{
			Image image = e.Source as Image;
			DataObject data = new DataObject(typeof(ImageSource), image.Source);
			DragDrop.DoDragDrop(image, data, DragDropEffects.Copy);
		}


		private void Img_Drop_1(object sender, DragEventArgs e)
		{
			Img.Source = e.Data.GetData(typeof(ImageSource)) as ImageSource;
		}

		private void ButtonOpenMenu1_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Collapsed;
			ButtonOpenMenu1.Visibility = Visibility.Collapsed;
			ButtonOpenMenu2.Visibility = Visibility.Collapsed;
			ButtonOpenMenu3.Visibility = Visibility.Collapsed;
			ButtonCloseMenu.Visibility = Visibility.Visible;
			string directory = @"C:\Users\User\Desktop\WPF\Ателье\Ателье\bin\Debug\images\Ткани";
			foreach (var file in Directory.GetFiles(directory).Where(f => f.EndsWith(".jpg") || f.EndsWith(".JPG")))
			{
				list.Items.Add(file);
			}
		}

		private void ButtonOpenMenu2_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Collapsed;
			ButtonOpenMenu1.Visibility = Visibility.Collapsed;
			ButtonOpenMenu2.Visibility = Visibility.Collapsed;
			ButtonOpenMenu3.Visibility = Visibility.Collapsed;
			ButtonCloseMenu.Visibility = Visibility.Visible;
			string directory = @"C:\Users\User\Desktop\WPF\Ателье\Ателье\bin\Debug\images\Окантовка";
			foreach (var file in Directory.GetFiles(directory).Where(f => f.EndsWith(".PNG") || f.EndsWith(".png")))
			{
				list.Items.Add(file);
			}
		}

		private void ButtonOpenMenu3_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Collapsed;
			ButtonOpenMenu1.Visibility = Visibility.Collapsed;
			ButtonOpenMenu2.Visibility = Visibility.Collapsed;
			ButtonOpenMenu3.Visibility = Visibility.Collapsed;
			ButtonCloseMenu.Visibility = Visibility.Visible;
			string directory = @"C:\Users\User\Desktop\WPF\Ателье\Ателье\bin\Debug\images\Фурнитура";
			foreach (var file in Directory.GetFiles(directory).Where(f => f.EndsWith(".jpg")))
			{
				list.Items.Add(file);
			}
		}

		private void DropImage(object sender, DragEventArgs e)
		{
			/*ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;
			Image imageControl = new Image() { Width = 100, Height = 100, Source = image };
			imageControl.MouseDown += StartDrag;
			//Вычисление X и Y
			Canvas.SetLeft(imageControl, e.GetPosition(DragArena).X);
			Canvas.SetTop(imageControl, e.GetPosition(DragArena).Y);
			DragArena.Children.Add(imageControl);*/
		}
	}
}
