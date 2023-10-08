using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            appLoop();
            Console.ReadLine();
        }

        static void appLoop()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Email:");
                string email = Console.ReadLine();
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();

                bool success = register(email, username, password);
            }
        }

        static bool login(string username, string password)
        {
            bool successful;
            string userId = "";
            using (var connection = new SqliteConnection(@"Data Source=User_Accounts.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    String.Format(@"
                        SELECT User_Id
                        FROM User
                        WHERE Username='{0}' AND Password='{1}'
                    ", username, password);


                using (var reader = command.ExecuteReader())
                {
                    successful = reader.HasRows;
                    while (reader.Read())
                    {
                        userId = reader.GetByte(0).ToString();
                    }
                    connection.Close();
                }
            }
            return successful;
        }

        static bool register(string email, string username, string password)
        {
            try
            {
                passwordValid(password);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            using (var connection = new SqliteConnection(@"Data Source=User_Accounts.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    String.Format(@"
                        INSERT INTO User
                        VALUES (NULL,'{0}', '{1}', '{2}')
                    ", email, username, password);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqliteException e)
                {
                    Console.WriteLine("Email or Username already in use");
                    return false;
                }
                connection.Close();
                return true;
            }
        }

        static bool passwordValid(string password)
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
                errorMessage += "Password does not contain 3+ numbers";
            }

            bool result = (password.Length >= 8 &&
                           has_capital &&
                           num_count >= 3 &&
                           has_special);

            if (result == false)
            {
                throw new ArgumentException(errorMessage);
            }
            return result;
        }
    }
}