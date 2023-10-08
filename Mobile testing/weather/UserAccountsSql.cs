using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace weather
{
    internal class UserAccountsSql
    {

        public static SqlConnection CreateReadOnlyConnection()
        {
            string connUsername = "UserAccountsReader"; //read only access login to database 
            string connPassword = "J!q-7pXnyV3e?cb9H#y%,pWh{=a%S_=h"; //password to login

            //the connection string to the Azure database
            //with read only permissions
            string connectionString = $"Server = tcp:mygarden-useraccounts.database.windows.net,1433; Initial Catalog = useraccounts; Persist Security Info = False; User ID = {connUsername}; Password = {connPassword}; MultipleActiveResultSets = True; Encrypt = True; TrustServerCertificate = True; Connection Timeout = 30;";
            return new SqlConnection(connectionString); //returns the connection 
        }

        public static SqlConnection CreateWriteOnlyConnection()
        {
            string connUsername = "UserAccountsWriter"; //write only access login to database 
            string connPassword = "e5m2Ngyqz88kYge3pX*[%#],,@gm9TN."; //password to login

            //the connection string to the Azure database
            //with write only permissions
            string connectionString = $"Server = tcp:mygarden-useraccounts.database.windows.net,1433; Initial Catalog = useraccounts; Persist Security Info = False; User ID = {connUsername}; Password = {connPassword}; MultipleActiveResultSets = True; Encrypt = True; TrustServerCertificate = True; Connection Timeout = 30;";

            return new SqlConnection(connectionString); //returns the connection 
        }

        public static bool UserExists(string username, string password)
        {
            SqlConnection connection = CreateReadOnlyConnection(); //creates a new read only connection to the database
            connection.Open(); //opens the connection

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //selects the entry from the users table where the username and password are the same as provided
            command.CommandText = $@"SELECT UserId
                                    FROM Users
                                    WHERE Username='{username}' AND Password='{password}';";

            SqlDataReader reader = command.ExecuteReader(); //executes the command
            return reader.Read(); //returns true if an entry has been found
        }

        public static Dictionary<string, string> GetUserData(string username, string password)
        {
            //creates and opens a new read only connection to the database
            SqlConnection connection = CreateReadOnlyConnection(); 
            connection.Open();

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //selects the entry from the users table where the username and password are the same as provided
            command.CommandText = $@"SELECT UserId, Email, Username
                                    FROM Users
                                    WHERE Username='{username}' AND Password='{password}';";

            //executes and gets the result of the command
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            //creates a dictionary object to store and return the user data
            Dictionary<string, string> userData = new Dictionary<string, string>
            {
                { "UserId", $"{reader.GetValue(0)}" },
                { "Email", $"{reader.GetValue(1)}" },
                { "Username", $"{reader.GetValue(2)}" }
            };
            reader.Close(); //closes the reader
            connection.Close(); //closes the connection

            return userData; //returns the users data in a dictionary format
        }

        public static Dictionary<string, string> GetUserGarden(string userId)
        {
            //creates and opens a new read only connection to the database
            SqlConnection connection = CreateReadOnlyConnection();
            connection.Open();

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //select the garden with the given user ID
            command.CommandText = $@"SELECT Serialised, Country, Postcode, Latitude, Longitude
                                    FROM Gardens
                                    WHERE UserId='{userId}';";

            //executes and gets the result of the command
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            //initialises a dictionary object with the garden data
            Dictionary<string, string> userData = new Dictionary<string, string>
            {
                { "Serialised", $"{reader.GetValue(0)}" },
                { "Country", $"{reader.GetValue(1)}" },
                { "Postcode", $"{reader.GetValue(2)}" },
                { "Latitude", $"{reader.GetValue(3)}" },
                { "Longitude", $"{reader.GetValue(4)}" }
            };

            reader.Close(); //closes the reader
            connection.Close(); //closes the connection 

            return userData; //returns the garden data in a dictionary format
        }

        public static string GetUserId(string username, string password)
        {
            //creates and opens a new read only connection to the database
            SqlConnection connection = CreateReadOnlyConnection();
            connection.Open();


            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //selects the ID from the entry with the given username and password
            command.CommandText = $@"SELECT UserId
                                    FROM Users
                                    WHERE Username='{username}' AND Password='{password}';";

            //executes and gets the result of the command
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            string userId = reader.GetInt32(0).ToString(); //converts the result to string
            reader.Close(); //closes the reader
            connection.Close(); //closes the connection

            return userId; //returns the user ID
        }

        public static bool UsernameInUse(string username)
        {
            //creates and opens a new read only connection to the database
            SqlConnection connection = CreateReadOnlyConnection(); 
            connection.Open();

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //finds a user entry with the given username 
            command.CommandText = $@"SELECT UserId
                                    FROM Users
                                    WHERE Username='{username}';";

            //executes and returns true if a user with the given username exists
            SqlDataReader reader = command.ExecuteReader();
            return reader.Read();
        }

        public static bool EmailInUse(string email)
        {
            //creates and opens a new read only connection to the database
            SqlConnection connection = CreateReadOnlyConnection();
            connection.Open();

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //finds a user entry with the given email
            command.CommandText = $@"SELECT UserId
                                    FROM Users
                                    WHERE Email='{email}';";

            //executes and returns true if a user with the given email exists
            SqlDataReader reader = command.ExecuteReader();
            return reader.Read();
        }

        public static void InsertNewUser(Dictionary<string, string> userData)
        {
            //creates and opens a new write only connection to the database
            SqlConnection connection = CreateWriteOnlyConnection();
            connection.Open();

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //insert a new entry into the user table with the given email, username and password
            command.CommandText = $@"INSERT INTO Users(Email, Username, Password)
                                    VALUES ('{userData["Email"]}','{userData["Username"]}','{userData["Password"]}');";

            //executes the command
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void InsertNewGarden(string userId)
        {
            //creates and opens a new write only connection to the database
            SqlConnection connection = CreateWriteOnlyConnection();
            connection.Open();

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //insert a new entry into the garden table with the given user ID
            command.CommandText = $@"INSERT INTO Gardens(UserId)
                                    VALUES ('{Convert.ToInt32(userId)}');";

            //executes the command
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateGardenLayout(string userId, string serialised)
        {
            //creates and opens a new write only connection to the database
            SqlConnection connection = CreateWriteOnlyConnection();
            connection.Open();

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //update an entry in the garden table with the given user ID with the given serialised garden data
            command.CommandText = $@"UPDATE Gardens
                                    SET Serialised='{serialised}'
                                    WHERE UserId='{userId}';";

            //executes the command
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateGardenLocation(string userId, string country, string postcode, string latitude, string longitude)
        {
            //creates and opens a new write only connection to the database
            SqlConnection connection = CreateWriteOnlyConnection();
            connection.Open();

            SqlCommand command = connection.CreateCommand(); //start to create a command to be executed within the database
            //update an entry in the garden table with the given user ID with the fiven location data
            command.CommandText = $@"UPDATE Gardens
                                    SET Country='{country}', Postcode='{postcode}', Latitude='{latitude}', Longitude='{longitude}'
                                    WHERE UserId='{userId}';";

            //executes the command
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
