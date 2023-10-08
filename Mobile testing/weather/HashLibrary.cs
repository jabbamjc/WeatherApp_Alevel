using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    internal class HashLibrary
    {
        public static string HashPassword(string password, string salt)
        {
            char[] chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray(); //create a list containing all characters
            byte[] byteStream = Encoding.ASCII.GetBytes(password + salt); //combine the password with the salt to make the hash more complex
            int rounds = password.Length; //run the hash an arbitrary amount of times to make it more complex
            for (int i = 0; i < rounds; i++)
            {
                int count = 0;
                foreach (byte b in byteStream) //perform the algorithm on each character
                {
                    byteStream[count] = (byte)chars[(b + (count ^ salt.Length)) % 62]; //create an index using the byte
                    count++;
                }
            }
            return Encoding.ASCII.GetString(byteStream); //return the byte list translated to 7-bit ascii
        }
    }
}
