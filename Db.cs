using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Günlük_Uygulaması
{
    public static class Db
    {
        public static SqlConnection Conn(){
            return new SqlConnection(" server = ESRA\\SQLEXPRESS01; DataBase = GunlukDb;Integrated Security=sspi;TrustServerCertificate=True;");        
        
        }


    }
}
