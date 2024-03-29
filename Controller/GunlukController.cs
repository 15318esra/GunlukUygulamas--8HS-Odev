﻿using Günlük_Uygulaması.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Günlük_Uygulaması.Controller
{
    public static class GunlukController
    {
        public static bool Add(Gunluk gunluk)
        {
            SqlConnection conn = Db.Conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gunlukler (Name, DateCreated) VALUES (@name, @Date) ", conn);
            cmd.Parameters.AddWithValue("name", gunluk.Name);
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
    }
}
