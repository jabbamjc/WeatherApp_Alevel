using Newtonsoft.Json;
using System.Collections;
using CommunityToolkit.Maui.Views;

namespace MyGardenApp;

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
				Temperature = Math.Round(Convert.ToDouble(hourWeather.temp), 0).ToString(),
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
		PlanterLayout.Clear(); //clear the current buttons shown on screen

		List<Planter> userPlanters = Garden.Planters; //Get the users current planters
													  
		if (userPlanters.Count > 0) //only update the planters if the user has any
		{
			//loop through the users Planters
			foreach (Planter planter in userPlanters)
			{
				//initialise a button representing the planter
				Button planterButton = new Button()
				{
					Text = planter.Name,
					TextColor = Color.FromArgb("#512bdf"),
					FontSize = 16,
					BorderWidth = 1,
					BorderColor = Colors.Black,
					BackgroundColor = Colors.White,
					Padding = 5,
					CornerRadius = 10,
					WidthRequest = 330,
				};
				//set the buttons Clicked event, passing the planter's name as an argument
				EventHandler planterButtonEventHandler = (sender, e) => OpenPlanterPage(planter.Name);
				planterButton.Clicked += planterButtonEventHandler;

				//initialise a button to delete the planter
				Button deleteButton = new Button()
				{
					Text = "X",
					TextColor = Color.FromArgb("#512bdf"),
					FontSize = 16,
					BorderWidth = 1,
					BorderColor = Colors.Black,
					BackgroundColor = Colors.White,
					Padding = 5,
					CornerRadius = 10,
					WidthRequest = 35,
				};
				//set the buttons Clicked event, passing the planter's name as an argument
				EventHandler deleteButtonEventHandler = (sender, e) => DeleteButtonClicked(planter.Name);
				deleteButton.Clicked += deleteButtonEventHandler;


				//initialise control to be displayed on screen 
				HorizontalStackLayout planterControl = new HorizontalStackLayout
				{
					Spacing = 5,
					Children =
                    {
						planterButton,
						deleteButton
                    }

				};

				//Show the control on the screen
				PlanterLayout.Add(planterControl);
			}
		}
	}

	private void DeleteButtonClicked(string name)
	{
		Garden.DeletePlanter(name); //Deletes the planter with given name
		UpdatePlanterList(); //Updates the control to show the change
	}

	private void OpenPlanterPage(string name)
	{
		//Creates a planter page using the data in the selected planter
		Application.Current.OpenWindow(new Window(new PlanterPage(name)));
	}

	Popup planterNamePopup; //makes the control accessable to the entire class
	Entry planterNameEntry; //makes the control accessable to the entire class
	private void CreatePlanterNamePopup()
	{
		//initialises an planter name entry control
		planterNameEntry = new Entry
		{
			FontSize = 16,
			Placeholder = "Name...",
			PlaceholderColor = Colors.DarkGray,
			MinimumWidthRequest = 100,
			HorizontalOptions = LayoutOptions.Center
		};

		//initialises a create planter button
		Button planterNameButton = new Button
		{
			FontSize = 16,
			Text = "Create Planter",
			BackgroundColor = Color.FromArgb("#512bdf"),
			WidthRequest = 120,
			HorizontalOptions = LayoutOptions.Center
		};
		//set the buttons Clicked event to create a new planter
		EventHandler buttonEventHandler = (sender, e) => AddNewPlanter();
		planterNameButton.Clicked += buttonEventHandler;

		//initialises the name entry popup to be shown on the screen 
		planterNamePopup = new Popup()
		{
			Size = new Size(200, 120),

			Content = new VerticalStackLayout
			{
				Padding = 5,
				Children =
				{
					new Label
					{
						FontSize = 16,
						TextColor = Color.FromArgb("#512bdf"),
						Text = "Name this planter",
						HorizontalOptions = LayoutOptions.Center
					},

					planterNameEntry,

					planterNameButton
				}
			}
		};
	}

	private void AddNewPlanterButtonClicked(object sender, EventArgs e)
	{
		CreatePlanterNamePopup(); //constructs a new popup control
		PopupExtensions.ShowPopup(Window.Page, planterNamePopup); //shows the popup on screen
	}

	private void AddNewPlanter()
	{
		planterNamePopup.Close(); //closes the name entry popup
		string planterName = planterNameEntry.Text; //gets name entered into the name entry popup

		//if the entered name is already in use
        if(Garden.Planters.Any(planter => planter.Name == planterName))
		{
			//initialises and shows a popup showing that the name is in use
			Popup nameInUsePopup = new Popup
			{
				Content = new Label { Text = "Name in use", FontSize = 32 }
			};
			PopupExtensions.ShowPopup(Window.Page, nameInUsePopup);
        }
		//if the entered name is not in use
        else
        {
			User.AddPlanter(planterName); //a new planter is added 
			UpdatePlanterList(); //the list control is updated to show the change
		}
	}

	private void SaveGardenButtonClicked(object sender, EventArgs e)
	{
		User.UpdateUserGarden(); //User class is called to save the current garden to the database
		Application.Current.OpenWindow(new Window(new GardenSetupPage()));
	}
}