using Newtonsoft.Json;
using System.Collections;
using CommunityToolkit.Maui.Views;

namespace weather;

public partial class GardenPage : ContentPage
{
	public GardenPage()
	{
		InitializeComponent();
		SetupWeatherScroll(); //sets up the 24 hour weather graphic
		UpdatePlanterList(); //reloads the users planters into the main list
		CheckGardenIsSetup(); //checks whether the user has initialised their garden's location
	}

	private static void CheckGardenIsSetup()
    {
		//if the user's location is not set
		if (!User.GardenLocationSet())
        {
			//take the user to the setup page
			Application.Current.OpenWindow(new Window(new GardenSetupPage()));
		}
	}

	private void SetupWeatherScroll()
	{
		//gets the next 24 hours of weather data
		HourWeather[] next24Hours = LoadWeatherRow(); 

		//loops through each hour
		foreach (HourWeather hour in next24Hours)
		{
			//converts the unix time to a real time
			DateTimeOffset time = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(hour.Time));

			//creates a new XAML control using the weather data and adds it to the scroll view on screen 
			WeatherScroll.Add(
				new Frame()
				{
					BorderColor = Colors.Black,
					BackgroundColor = Color.FromArgb("#512bdf"),
					Padding = 5,
					CornerRadius = 10,

					Content = new VerticalStackLayout()
					{
						new Label() { Text=$"{time.Hour}:00", FontSize=24, TextColor=Colors.White, HorizontalOptions=LayoutOptions.Center },
						new BoxView() { Color=Colors.Black, HeightRequest=2 },
						new Image() { Source=$"icon{hour.Icon}.png", HeightRequest=80 },
						new BoxView() { Color=Colors.Black, HeightRequest=2 },
						new Label() { Text=$"{hour.Temperature}°c", FontSize=24, TextColor=Colors.White, HorizontalOptions=LayoutOptions.Center }
					}
				}
			);
		}
	}

	private HourWeather[] LoadWeatherRow()
	{
		//gets the garden's coordinates
		Dictionary<string, string> coordinates = User.GetGardenCoordinates(); 

		//calls the hourly weather API using the OpenWeatherApiClass
		string weatherData = OpenWeatherApiClass.GetHourlyForecast(coordinates["Latitude"], coordinates["Longitude"]);

		//deserialises the API response into a .net object
		dynamic weatherDataJson = JsonConvert.DeserializeObject(weatherData);

		//initialises an hourweather list
		HourWeather[] next24Hours = new HourWeather[24];

		//loops through the first 24 hours of weather data
		for (int i = 0; i < 24; i++)
		{
			//selects the data for the hour
			dynamic hourWeather = weatherDataJson.hourly[i];

			//initialises a new hourweather instance using the API response data
			HourWeather hour = new()
			{
				Time = hourWeather.dt,
				Temperature = Math.Round(Convert.ToDouble(hourWeather.temp),0).ToString(),
				Humidity = hourWeather.humidity,
				WindSpeed = hourWeather.wind_speed,
				Icon = hourWeather.weather[0].icon
			};

			if (hourWeather.rain != null) // rain data is not always provided so it must be checked
            {
				hour.Rain = hourWeather.rain.ToString();
            }
			next24Hours[i] = hour; //adds the hourweather class to the array
		}
		return next24Hours; //returns the list of hourweather entities
	}

	private void UpdatePlanterList()
    {
		ArrayList userPlanters = User.GetPlanters(); //Get the users current planters
		//only update the planters if the user has any
		if(userPlanters.Count > 0)
        {
			PlanterLayout.Clear(); //clear the current buttons shown on screen
			//loop through the users Planters
			foreach (Planter planter in userPlanters)
			{
				//initialise button control using data from an HourData object
				Button planterButton = new Button()
				{
					Text = planter.Name + "\n\n",
					TextColor = Color.FromArgb("#512bdf"),
					FontSize = 16,
					BorderWidth = 1,
					BorderColor = Colors.Black,
					BackgroundColor = Colors.White,
					Padding = 5,
					CornerRadius = 10,
				};
				//set the buttons Clicked event
				EventHandler buttonEventHandler = (sender, e) => OpenPlanterPage();
				planterButton.Clicked += buttonEventHandler; 
				//Show the button on the screen
				PlanterLayout.Add(planterButton);
			}
		}
	}

	private void OpenPlanterPage()
    {
		//Application.Current.OpenWindow(new Window(new GardenSetupPage()));
		var popup = new Popup()
		{
			Content = new VerticalStackLayout
			{
				Children =
				{
					new Label
					{
						Text = "This is a very important message!"
					}
				}
			}
		};
        //ShowPopup(popup);
	}

	private void AddNewPlanter(object sender, EventArgs e)
	{
        User.AddPlanter("planter1"); //a new planter is added 
		UpdatePlanterList();
	}

	private void SaveGardenButtonClicked(object sender, EventArgs e)
    {
		User.UpdateUserGarden();
		CheckGardenIsSetup();
	}
}