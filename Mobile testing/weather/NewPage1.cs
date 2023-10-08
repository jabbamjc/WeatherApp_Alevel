using Microsoft.Maui.Controls;

namespace weather
{
	public class NewPage1 : ContentPage
	{
		public NewPage1()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Welcome to .NET MAUI!" }
				}
			};
		}
	}
}