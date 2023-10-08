using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    internal class OpenWeatherApiClass
    {
		private static string Key = "d9ba5383a9b9e7326a640d8416e3b158";

		public static string GetHourlyForecast(string latitude, string longitude)
		{
			string sURL = $@"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=current,minutely,daily,alerts&appid={Key}&units=metric";

			HttpClient client = new();
			string responseBody = client.GetStringAsync(sURL).Result;

			return responseBody;
		}

		public static string ReverseGeocode(string postcode, string countryCode)
		{
			string sURL = $@"https://api.openweathermap.org/geo/1.0/zip?zip={postcode},{countryCode}&appid={Key}";

			HttpClient client = new();
			string responseBody = client.GetStringAsync(sURL).Result;

			return responseBody;
		}
	}
}
