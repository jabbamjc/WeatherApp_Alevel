using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MauiApp1
{
	public partial class PlantIdentifierPage : ContentPage
	{
		public PlantIdentifierPage()
		{
			InitializeComponent();
		}
		private void OnBackButtonClicked(object sender, EventArgs e)
		{
			Window mainWindow = new Window(new MainPage());
			Application.Current.OpenWindow(mainWindow);
		}
	}
}