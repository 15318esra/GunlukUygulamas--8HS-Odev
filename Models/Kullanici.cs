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
        public string Password { get; set; }
    }
}
