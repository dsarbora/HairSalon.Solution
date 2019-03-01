using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Customer
    {
        int Id;
        string Name;
        int EmployeeId;

        public Customer(string name, int employeeId, int id=0)
        {
            Name=name;
            EmployeeId=employeeId;
            Id=id;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetId()
        {
            return Id;
        }

        public int GetEmployeeId()
        {
            return EmployeeId;
        }

        public void Save()
        {

        }

        public void Edit(string name)
        {

        }

        public void Delete()
        {

        }

        public static void ClearAll()
        {

        }

        public override bool Equals(System.Object otherCustomer)
        {

        }

        public static Customer Find(int id)
        {

        }
    }

}