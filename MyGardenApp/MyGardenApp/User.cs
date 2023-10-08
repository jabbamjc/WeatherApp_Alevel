using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;

namespace MyGardenApp
{
    internal class User : UserAccountSql
    {
        public static string UserId { get; set; } //makes the User's UserID globally avaliable
        public static string Email { get; set; } //makes the User's Email globally avaliable
        public static string Username { get; set; } //makes the User's Username globally avaliable
        public static Garden Garden { get; set; } //makes the User's Garden globally avaliable

        public User(Dictionary<string, string> userData, Dictionary<string, string> userGarden)
        {
            UserId = userData["UserId"]; //sets the UserId
            Email = userData["Email"]; //sets the Email
            Username = userData["Username"]; //sets the username

            Garden = new Garden(userGarden); //initialises the garden 
        }

        public static User Login(string username, string password)
        {
            //gets the user data for the given username and password
            Dictionary<string, string> userData = GetUserData(username, password);
            //gets the garden data for the retrieved user
            Dictionary<string, string> userGarden = GetUserGarden(userData["UserId"]);

            //initialises the class using the user's account and garden data
            return new User(userData, userGarden);
        }

        public static User Register(string email, string username, string password)
        {
            //initialises a dictionary containing the new account data
            Dictionary<string, string> userData = new Dictionary<string, string>
            {
                { "Email", $"{email}" },
                { "Username", $"{username}" },
                { "Password", $"{password}" }
            };

            //uses the UserAccountSql functionality to insert a new user into the database
            InsertNewUser(userData);

            string userId = GetUserId(username, password); //retrives the new user's User Id
            //uses the UserAccountSql functionality to insert a new garden into the database for the retrieved user
            InsertNewGarden(userId);

            //initialises the class using the new user's account and garden data
            return Login(username, password);
        }

        public static Dictionary<string, string> Serialise()
        {
            //initialises a dictionary with the 
            Dictionary<string, string> userData = new Dictionary<string, string>
            {
                { "UserId", $"{UserId}" },
                { "Email", $"{Email}" },
                { "Username", $"{Username}" }
            };
            return userData;
        }

        public static Dictionary<string, string> GetGardenCoordinates()
        {
            //gets the garden's coordinates
            string latitude = Garden.Latitude;
            string longitude = Garden.Longitude;

            //if the coordinates arent set yet then returns 0,0
            if (latitude == "")
            {
                latitude = "0";
            }
            if (longitude == "")
            {
                longitude = "0";
            }

            //initialises a dictionary with the coordinates
            Dictionary<string, string> result = new()
            {
                { "Latitude", latitude },
                { "Longitude", longitude }
            };

            return result; //returns the coordinates
        }

        public static void AddPlanter(string name)
        {
            Garden.AddPlanter(name); //adds a planter to the garden
        }

        public static void UpdateUserGarden()
        {
            //uses the UserAccountSql functionality to update the user's garden stored in the database
            UpdateGardenLayout(UserId, SerialiseGarden());
        }

        public static string SerialiseGarden()
        {
            return JsonConvert.SerializeObject(Garden.Planters); //serialises the garden to json format 
        }

        public static bool GardenLocationSet()
        {
            return Garden.LocationSet();
        }
    }
}
