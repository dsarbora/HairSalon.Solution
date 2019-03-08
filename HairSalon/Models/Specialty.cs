using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
    public class Specialty
    {
        private int Id;
        private string Name;
        public Specialty(string name, int id=0)
        {
            Name=name;
            Id=id;
        }

        public int GetId() { return Id; }
        public string GetName() { return Name; }
        public void SetName(string name) { Name = name; }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM specialties; DELETE FROM employee_specialty; DELETE FROM client_specialty;", conn);
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM specialties;", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(name, id);
                allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        public static Specialty Find(int id)
        {
            MySqlConnection conn= DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("GET * FROM specialties WHERE id = @id;", conn);
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@id";
            prmId.Value = id;
            cmd.Parameters.Add(prmId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            string name="";
            while(rdr.Read())
            {
                name=rdr.GetString(1);
            }
            Specialty newSpecialty = new Specialty(name, id);
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return newSpecialty;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO specialties (name) VALUES (@name);", conn);
            MySqlParameter prmName = new MySqlParameter();
            prmName.ParameterName = "@name;";
            prmName.Value = Name;
            cmd.Parameters.Add(prmName);
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        }
    }
}