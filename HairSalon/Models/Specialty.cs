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

        public void Save()
        {

        }
    }
}