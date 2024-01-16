using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Günlük_Uygulaması.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }= DateTime.Now;


        
    }
}
