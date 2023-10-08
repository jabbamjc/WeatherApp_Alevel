//using SQLite;
using Microsoft.Data.SqlClient;

namespace UserAccountFunctionality
{
    class LoginClass
    {
        public static SqlConnection CreateConnection()
        {
            string connUsername = "UserAccountsReader";
            string connPassword = "J!q-7pXnyV3e?cb9H#y%,pWh{=a%S_=h";
            string connectionString = $"Server=tcp:mygardenapp-user-accounts.database.windows.net,1433;Initial Catalog=User_Accounts;Persist Security Info=False;User ID={connUsername};Password={connPassword};MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

            SqlConnection connection = new(connectionString);
            return connection;
        }

        public static bool Login(string username, string password)
        {
            SqlConnection connection = CreateConnection();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $@"SELECT UserId
                                    FROM Users
                                    WHERE Username='{username}' AND Password='{password}';";

            return command.ExecuteReader().Read();
        }

        public static bool Register(string email, string username, string password)
        {
            SqlConnection connection = CreateConnection();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $@"INSERT INTO Users (Email, Username, Password)
                                    VALUES ('{email}', '{username}', '{password}');";
            return command.ExecuteReader().Read();
        }

        public static bool EmailInUse(string email)
        {
            SqlConnection connection = CreateConnection();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $@"SELECT UserId
                                    FROM Users
                                    WHERE Email='{email}';";

            SqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            reader.Close();
            connection.Close();
            return result;
        }

        public static bool UsernameInUse(string username)
        {
            SqlConnection connection = CreateConnection();
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $@"SELECT UserId
                                    FROM Users
                                    WHERE Username='{username}';";
            
            SqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            reader.Close();
            connection.Close();
            return result;
        }

        public static bool PasswordValid(string password)
        {
            bool has_capital = false;
            bool has_special = false;
            int num_count = 0;
            foreach (char c in password)
            {
                if (c >= 65 && c <= 90)
                {
                    has_capital = true;
                }
                if (c >= 48 && c <= 57)
                {
                    num_count++;
                }
                if (!(c >= 65 && c <= 90) && !(c >= 48 && c <= 57) && !(c >= 97 && c <= 122) && c >= 33)
                {
                    has_special = true;
                }
            }

            string errorMessage = "";
            if (password.Length < 8)
            {
                errorMessage += "Password does not contain 8+ characters\n";
            }
            if (has_capital == false)
            {
                errorMessage += "Password does not contain a capital\n";
            }
            if (num_count < 3)
            {
                errorMessage += "Password does not contain 3+ numbers\n";
            }
            if (has_special == false)
            {
                errorMessage += "Password does not contain special character";
            }

            bool result = (password.Length >= 8 &&
                           has_capital &&
                           num_count >= 3 &&
                           has_special);

            //if (result == false)
            //{
            //    throw new ArgumentException(errorMessage);
            //}
            return result;
        }

        public static bool HasEightCharacters(string password)
        {
            return (password.Length >= 8);
        }
        public static bool HasOneCapital(string password)
        {
            bool hasCapital = false;
            foreach (char c in password)
            {
                if (c >= 65 && c <= 90)
                {
                    hasCapital = true;
                }
            }
            return hasCapital;
        }
        public static bool HasThreeNumbers(string password)
        {
            int numCount = 0;
            foreach (char c in password)
            {
                if (c >= 48 && c <= 57)
                {
                    numCount++;
                }
            }
            return (numCount >= 3);
        }
        public static bool HasSpecialCharacter(string password)
        {
            bool hasSpecial = false;
            foreach (char c in password)
            {
                if (!(c >= 65 && c <= 90) && !(c >= 48 && c <= 57) && !(c >= 97 && c <= 122) && c >= 33)
                {
                    hasSpecial = true;
                }
            }
            return hasSpecial;
        }

    }
}

