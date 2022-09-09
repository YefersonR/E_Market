using System.Security.Cryptography;
using System.Text;

namespace E_Market.Core.Application.Helpers
{
    public class PasswordEncryption
    {
        public static string ComputeHash(string password)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new();
                for(int i = 0; i< bytes.Length; i++) 
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        } 

    }
}
