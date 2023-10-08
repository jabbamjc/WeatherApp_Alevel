namespace MyGardenApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		Application.Current.OpenWindow(new Window(new LoginPage()));
	}
}

