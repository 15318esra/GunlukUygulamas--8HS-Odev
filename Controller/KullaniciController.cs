using Günlük_Uygulaması.Models;
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
        public static bool Login(Kullanici user)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM Users WHERE Username=@username AND Password=@password", conn);
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("password", user.Password);

            conn.Open();
            object loginUser = cmd.ExecuteScalar();
            conn.Close();
            return loginUser != null;
        }
    }
}
