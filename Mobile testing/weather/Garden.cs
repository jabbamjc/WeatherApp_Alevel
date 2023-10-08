using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace weather
{
    internal class Garden
    {
        public static string Country { get; set; }
        public static string Latitude { get; set; } 
        public static string Longitude { get; set; }
        public static ArrayList Planters { get; set; }

        public Garden(Dictionary<string, string> userGarden)
        {
            Country = userGarden["Country"]; //sets the country
            Latitude = userGarden["Latitude"]; //sets the latitude
            Longitude = userGarden["Longitude"]; //sets the longitude

            //deserialises the seralised data and initialises the planters using the data
            Planters = DeserialisePlanters(userGarden["Serialised"]); 
        }

        public static bool LocationSet()
        {
            return !(Country == ""); //checks if the database value for country is null 
        }

        public static void Serialise()
        {
            
        }

        public static void AddPlanter(string name)
        {
            Planters.Add(new Planter(name)); //adds a new planter to the planters
        }

        public static ArrayList DeserialisePlanters(string serialised)
        {
            ArrayList planters = new(); //initialises a new dynamic list of planters

            //deserialises the serialised string using the Newtonsoft library
            dynamic json = JsonConvert.DeserializeObject(serialised);

            //returns an empty list if the user has no planters saved
            if (json == null)
            {
                return planters;
            }

            //loops through each planter and adds a planter to the list
            foreach (dynamic item in json)
            {
                planters.Add(new Planter(item.Name.ToString()));
            }

            //returns the deserialised planter list
            return planters;
        }
    }
}
