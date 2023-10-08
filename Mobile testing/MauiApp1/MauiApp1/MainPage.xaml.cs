namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	private void OnMyGardenButtonClicked(object sender, EventArgs e)
	{
		Window myGardenWindow = new Window(new MyGardenPage());
		Application.Current.OpenWindow(myGardenWindow);
	}
	private void OnWeatherButtonClicked(object sender, EventArgs e)
	{
		Window myGardenWindow = new Window(new WeatherPage());
		Application.Current.OpenWindow(myGardenWindow);
	}
	private void OnPlantIdentifierButtonClicked(object sender, EventArgs e)
	{
		Window myGardenWindow = new Window(new PlantIdentifierPage());
		Application.Current.OpenWindow(myGardenWindow);
	}
}

