using Günlük_Uygulaması.Models;
using Günlük_Uygulaması.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Günlük_Uygulaması.Controller
{
    public class KullaniciController
    {
        // Diğer metotlar...

        public static bool AddUser(Kullanici user)
        {
            using (SqlConnection conn = Db.Conn())
            {
                conn.Open();

                
                SqlCommand addUserCmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@username, @password)", conn);
                addUserCmd.Parameters.AddWithValue("username", user.Username);
                addUserCmd.Parameters.AddWithValue("password", Helper.Base64Encode(user.Password));

                try
                {
                    addUserCmd.ExecuteNonQuery();
                    return true; 
                   
                }
                catch (SqlException)
                {
                    return false; 

                    
                }
            }
        }
    }
}
