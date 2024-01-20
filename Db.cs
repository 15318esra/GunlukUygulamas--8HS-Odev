using Günlük_Uygulaması.Utils;
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
        public static SqlConnection Conn()
        {
            return new SqlConnection(" server = ESRA\\SQLEXPRESS01; DataBase = GunlukDb;Integrated Security=sspi;TrustServerCertificate=True;");

        }
        public static void ChangePassword(string username, string newPassword)
        {
            using (SqlConnection conn = Conn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Password=@newPassword WHERE Username=@username", conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("newPassword", Helper.Base64Encode(newPassword)); 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ListEntriesByDate(string username, DateTime date)
        {
            using (SqlConnection conn = Conn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT EntryDate, EntryText FROM Gunlukler WHERE Username=@username AND CONVERT(DATE, EntryDate) = CONVERT(DATE, @date)", conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("date", date);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetDateTime(0)}\n{reader.GetString(1)}\n-------------");
                        }
                    }
                }
            }


        }
    }
}