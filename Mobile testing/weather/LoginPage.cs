using Microsoft.Maui.Controls;

namespace weather
{
	public class LoginPage : ContentPage
	{
		public LoginPage()
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