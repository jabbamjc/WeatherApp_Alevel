using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace weather
{
    internal class HourWeather
    {
        public string Time { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string WindSpeed { get; set; }
        [JsonProperty("1h")]
        public string Rain { get; set; }
        public string Icon { get; set; }
    }
}
