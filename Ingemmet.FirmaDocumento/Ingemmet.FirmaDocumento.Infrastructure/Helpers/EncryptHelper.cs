using System;
using System.Security.Cryptography;
using System.Text;

namespace Ingemmet.FirmaDocumento.Infrastructure.Helpers
{
    public class EncryptHelper
    {
        private const string key = "1NG3MM3T2020$";

        public static string GetSHA256(string text, string salt = null)
            => ComputeHash(text, new SHA256CryptoServiceProvider(), GetSalt(salt));       


        private static Byte[] GetSalt(string salt)
        {
            if (string.IsNullOrEmpty(salt))
                return Encoding.UTF8.GetBytes(key);

            return Encoding.UTF8.GetBytes(salt);
        }

        private static string ComputeHash(string input, HashAlgorithm algorithm, Byte[] salt)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] saltedInput = new Byte[salt.Length + inputBytes.Length];
            salt.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, salt.Length);

            Byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
