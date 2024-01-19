using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Günlük_Uygulaması.Utils
{
    public class Helper
    {
        // şifrelemek için.
        public static string Base64Encode(string text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }
        // Şifreleri çözmek için.
        public static string Base64Decode(string base64)
        {
            byte[] base64Bytes = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(base64Bytes);
        }
    }
}
