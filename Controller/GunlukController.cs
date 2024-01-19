using Günlük_Uygulaması.Models;
using Günlük_Uygulaması.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Günlük_Uygulaması.Controller
{
    public static class GunlukController
    {
        public static bool Add(Gunluk gunluk)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gunlukler (Name, DateCreated) VALUES (@name, @Date) ", conn);
            cmd.Parameters.AddWithValue("name", Helper.Base64Encode(gunluk.Name));
            cmd.Parameters.AddWithValue("Date", gunluk.DateCreated);
            conn.Open();
            int affedtedRows = cmd.ExecuteNonQuery();
            conn.Close();

            if (affedtedRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Gunluk> GetAll()
        {
            List<Gunluk> list = new List<Gunluk>();
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("SELECT Id, Name, DateCreated FROM Gunlukler", conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Gunluk 
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    DateCreated = (DateTime) dr["DateCreated"]
                });
            }
            dr.Close();
            conn.Close();
            return list;
        }
        public static bool DeleteAll()
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gunlukler ",conn);


            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            if (affectedRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckCurrentDateHasDiary()
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) Id FROM Gunlukler WHERE YEAR(DateCreated)=YEAR(GETDATE()) AND MONTH(DateCreated)=MONTH(GETDATE()) AND DAY(DateCreated) = DAY(GETDATE())", conn);
            conn.Open();
            int affectedRows = cmd.ExecuteScalar() == null ? 0 : (int)cmd.ExecuteScalar();
            conn.Close();

            return affectedRows > 0;
        }
        public static bool Update(Gunluk gunluk)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("UPDATE Gunlukler SET Name=@name WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("id", gunluk.Id);
            cmd.Parameters.AddWithValue("name", gunluk.Name);

            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0;
        }
        public static List<Gunluk> GunlukArama(DateTime tarih)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("SELECT Id, Name, DateCreated FROM Gunlukler WHERE YEAR(DateCreated)=@year AND MONTH(DateCreated)=@month AND DAY(DateCreated)=@day", conn);
            cmd.Parameters.AddWithValue("year", tarih.Year);
            cmd.Parameters.AddWithValue("month", tarih.Month);
            cmd.Parameters.AddWithValue("day", tarih.Day);

            List<Gunluk> gunlukler = new List<Gunluk>();

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                gunlukler.Add(new Gunluk
                {
                    Id = (int)dr["Id"],
                    Name = Helper.Base64Decode((string)dr["Name"]),
                    DateCreated = (DateTime)dr["DateCreated"],
                });
            }
            dr.Close();
            conn.Close();
            return gunlukler;
        }
        public static bool RemoveById(int id)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gunlukler WHERE Id = @id ", conn);
            cmd.Parameters.AddWithValue("id", id);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0;
        }
    }
}
