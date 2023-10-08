using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGardenApp
{
    internal class OpenWeatherApiClass
    {
		//Sets the API connection key constant for use throughout the class
		private const string Key = "d9ba5383a9b9e7326a640d8416e3b158"; 

		public static string GetHourlyForecast(string latitude, string longitude)
		{
			//creates an hourly weather API call for the given co-ordinates
			string connectionString = $@"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=current,minutely,daily,alerts&appid={Key}&units=metric";

			//calls the API using the connection string and gets the result
			HttpClient client = new();
			string responseBody = client.GetStringAsync(connectionString).Result;

			//returns the API response
			return responseBody;
		}

		public static string ReverseGeocode(string postcode, string countryCode)
		{
			//creates a geocoding API call for the given country and postcode
			string connectionString = $@"https://api.openweathermap.org/geo/1.0/zip?zip={postcode},{countryCode}&appid={Key}";

			//calls the API using the connection string and gets the result
			HttpClient client = new();
			string responseBody = client.GetStringAsync(connectionString).Result;

			//returns the API response
			return responseBody;
		}
	}
}
