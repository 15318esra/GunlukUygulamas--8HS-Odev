using System;
using System.Security.Cryptography;
using System.Text;

namespace Günlük_Uygulaması.Utils
{
    public class Helper
    {
        // SHA-256 algoritması ile şifreleme
        public static string Sifrele(string metin)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(metin));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Base64 algoritması ile şifreleme
        public static string Base64Encode(string text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }

        // Base64 algoritması ile çözme
        public static string Base64Decode(string base64)
        {
            byte[] base64Bytes = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(base64Bytes);
        }
    }
}
