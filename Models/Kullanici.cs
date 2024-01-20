using Günlük_Uygulaması.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Günlük_Uygulaması.Models
{
    public class Kullanici : BaseModel
    {
        public string Username { get; set; }
        private string _password; 

        // Password property'sini şifreleyip çözen property 
        public string Password
        {
            get { return Helper.Base64Decode(_password); }
            set { _password = Helper.Base64Encode(value); }
        }
    }
}
