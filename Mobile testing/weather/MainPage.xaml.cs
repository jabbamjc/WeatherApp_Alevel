namespace weather;
using Newtonsoft.Json;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		LoadWeather();
		SetupWeatherScroll();
	}

	private void SetupWeatherScroll()
    {
		HourWeather[] next24Hours = LoadWeatherRow();
		foreach (HourWeather hour in next24Hours)
		{
			DateTimeOffset time = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(hour.Time));

			WeatherScroll.Add(
				new Frame()
				{
					BorderColor = Colors.Black,
					BackgroundColor = Color.FromHex("#512bdf"),
					Padding = 5,
					CornerRadius = 10,

					Content = new VerticalStackLayout()
					{
						new Label() { Text=$"{time.Hour}:00", FontSize=32, TextColor=Colors.White, HorizontalOptions=LayoutOptions.Center },
						new BoxView() { Color=Colors.Black, HeightRequest=2 },
						new Image() { Source=$"icon{hour.Icon}.png", HeightRequest=100 }
					}
				}
			);
		}
    }

	private void LoadWeather()
	{
		Task<string> CallApi = Task<string>.Factory.StartNew(() =>
		{
			string userLocation = "london"; //change
			string sURL = String.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid=d9ba5383a9b9e7326a640d8416e3b158&units=metric", userLocation);

			HttpClient client = new HttpClient();
			string responseBody = client.GetStringAsync(sURL).Result;

			return responseBody;
		});

		string weatherData = CallApi.Result;
		dynamic weatherDataJson = JsonConvert.DeserializeObject(weatherData);

		//LocationLabel.Text = weatherDataJson.name;
		TemperatureLabel.Text = Math.Round(Convert.ToDouble(weatherDataJson.main.temp), MidpointRounding.ToEven).ToString() + "°c";
		WeatherDescriptionLabel.Text = weatherDataJson.weather[0].description;
		WeatherIcon.Source = String.Format("icon{0}.png", weatherDataJson.weather[0].icon.ToString());
	}

	private void OnReloadButtonClicked(object sender, EventArgs e)
	{
		Task<string> CallApi = Task<string>.Factory.StartNew(() => 
		{
			string userLocation = UserLocationPicker.SelectedItem.ToString(); //change
			string sURL = String.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid=d9ba5383a9b9e7326a640d8416e3b158&units=metric", userLocation);

			HttpClient client = new HttpClient();
            string responseBody = client.GetStringAsync(sURL).Result;

			return responseBody;
		});

		string weatherData = CallApi.Result;
		dynamic weatherDataJson = JsonConvert.DeserializeObject(weatherData);

		TemperatureLabel.Text = Math.Round(Convert.ToDouble(weatherDataJson.main.temp), MidpointRounding.ToEven).ToString() + "°c";
		WeatherDescriptionLabel.Text = weatherDataJson.weather[0].description;
		WeatherIcon.Source = String.Format("icon{0}.png", weatherDataJson.weather[0].icon.ToString());
	}

	private HourWeather[] LoadWeatherRow()
    {
		Task<string> CallApi = Task<string>.Factory.StartNew(() =>
		{
			string sURL = $@"https://api.openweathermap.org/data/2.5/onecall?lat=50.8332466&lon=-0.3722449&exclude=current,minutely,daily,alerts&appid=d9ba5383a9b9e7326a640d8416e3b158&units=metric";

			HttpClient client = new();
			string responseBody = client.GetStringAsync(sURL).Result;

			return responseBody;
		});

		string weatherData = CallApi.Result;
		dynamic weatherDataJson = JsonConvert.DeserializeObject(weatherData);

		HourWeather[] next24Hours = new HourWeather[24];
		for (int i = 0; i < 24; i++)
		{
			dynamic hourWeather = weatherDataJson.hourly[i];
			HourWeather hour = new()
			{
				Time = hourWeather.dt,
				Temperature = hourWeather.temp,
				Humidity = hourWeather.humidity,
				WindSpeed = hourWeather.wind_speed,
				Rain = hourWeather.rain,
				Icon = hourWeather.weather[0].icon
			};
			next24Hours[i] = hour;
		}
		return next24Hours;
	}

	private void OpenLoginWindow(object sender, EventArgs e)
    {
		Application.Current.OpenWindow(new Window(new LoginPage()));
    }
}

