using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;

namespace MyGardenApp
{
    internal class Garden
    {
        public static string Country { get; set; }
        public static string Latitude { get; set; }
        public static string Longitude { get; set; }
        public static List<Planter> Planters { get; set; }

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

        public static string Serialise()
        {
            //converts the Planters list to a JSON string and returns the result
            return JsonConvert.SerializeObject(Planters);
        }

        public static void AddPlanter(string name)
        {
            Planters.Add(new Planter(name)); //adds a new planter to the planters
        }

        public static void DeletePlanter(string name)
        {
            int index = GetPlanterIndex(name); //gets the index position of the planter with the given name
            Planters.RemoveAt(index); //removes the planter at the given index
        }

        public static List<Planter> DeserialisePlanters(string serialised)
        {
            List<Planter> planters = new(); //initialises a new dynamic list of planters

            //deserialises the serialised string using the Newtonsoft library
            dynamic json = JsonConvert.DeserializeObject(serialised);

            //only attempts to reconstruct if the user has planters saved
            if (json != null)
            {
                //loops through each planter 
                foreach (dynamic planter in json)
                {
                    //initialises a new Planter instance
                    Planter newPlanter = new Planter(planter.Name.ToString());

                    //loops through each plant 
                    foreach (dynamic plant in planter.Plants)
                    {
                        //adds new plant to planter
                        newPlanter.AddPlant(plant.Name.ToString());
                    }

                    //adds the instance to the list
                    planters.Add(newPlanter);
                }
            }

            //returns the deserialised planter list
            return planters;
        }

        public static int GetPlanterIndex(string planterName)
        {
            //finds the index position of the planter with the given name
            return Planters.FindIndex(plant => plant.Name == planterName);
        }
    }
}

