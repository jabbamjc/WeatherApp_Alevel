using System;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MauiApp1
{
	public partial class MyGardenPage : ContentPage
	{
		public MyGardenPage()
		{
			InitializeComponent();
		}

		private void OnBackButtonClicked(object sender, EventArgs e)
		{
			Window mainWindow = new Window(new MainPage());
			Application.Current.OpenWindow(mainWindow);
		}
	}

	public class GraphicsDrawable : IDrawable
	{
		public void Draw(ICanvas canvas, RectangleF dirtyRect)
		{
			SolidPaint solidPaint = new SolidPaint(Colors.Silver);
			RectangleF solidRectangle = new RectangleF(100, 100, 200, 100);
			canvas.SetFillPaint(solidPaint, solidRectangle);
			canvas.SetShadow(new SizeF(10, 10), 10, Colors.Grey);
			canvas.FillRoundedRectangle(solidRectangle, 12);
		}
	}
}