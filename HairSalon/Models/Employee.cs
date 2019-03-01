using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Employee
    {
        int Id;
        string Name;

        public Employee(string name, string id)
        {
            Name=name;
            Id=id;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetId()
        {
            return Id;
        }

        public void Save()
        {
            
        }

        public void Edit(string newName)
        {

        }

        public void Delete()
        {

        }

        public List<Customer> GetAllCustomers()
        {

        }

        public override bool Equals(System.Object otherEmployee)
        {

        }

        public static Employee Find(int id)
        {

        }

        public static List<Employee> GetAll()
        {

        }

        public static void ClearAll()
        {

        }
    }
}