using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Employee
    {
        int Id;
        string Name;

        public Employee(string name, int id=0)
        {
            Name=name;
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

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO employees (name) VALUES (@name);";
            MySqlParameter prmName = new MySqlParameter();
            prmName.ParameterName = "@name";
            prmName.Value = Name;
            cmd.Parameters.Add(prmName);
            cmd.ExecuteNonQuery();
            Id=(int)cmd.LastInsertedId;
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        }

        public void Edit(string newName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE employees SET name=@name WHERE id=@id;";
            MySqlParameter prmName = new MySqlParameter();
            prmName.ParameterName = "@name";
            prmName.Value = newName;
            cmd.Parameters.Add(prmName);
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@id";
            prmId.Value = Id;
            cmd.Parameters.Add(prmId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM employees WHERE id=@id; DELETE FROM customer_employee WHERE id = @id";
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@id";
            prmId.Value = Id;
            cmd.Parameters.Add(prmId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn!=null)
            {
                conn.Dispose();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> allClients = new List<Customer>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT customers.* FROM employees JOIN customer_employee ce ON (ce.employee_id=employees.id) JOIN customers ON (customers.id = ce.customer_id) WHERE employee_id = @employee_id;";
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@employee_id";
            prmId.Value = Id;
            cmd.Parameters.Add(prmId);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Customer newCustomer = new Customer(name, id);
                allClients.Add(newCustomer);
            }
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public override bool Equals(System.Object otherEmployee)
        {
            if(!(otherEmployee is Employee))
            {
                return false;
            }
            else
            {
                Employee newEmployee = (Employee)otherEmployee;
                bool nameEquality = this.GetName().Equals(newEmployee.GetName());
                bool idEquality = this.GetId().Equals(newEmployee.GetId());
                return (nameEquality && idEquality);
            }
        }

        public static Employee Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM employees WHERE id=@id;";
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@id";
            prmId.Value = id;
            cmd.Parameters.Add(prmId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            rdr.Read();
            Employee newEmployee = new Employee(rdr.GetString(1), id);
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return newEmployee;
        }

        public static List<Employee> GetAll()
        {
            List<Employee> allEmployees = new List<Employee>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM employees;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                Employee newEmployee = new Employee(rdr.GetString(1), rdr.GetInt32(0));
                allEmployees.Add(newEmployee);
            }
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return allEmployees;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand(); //as MySqlCommand;
            cmd.CommandText = @"DELETE FROM employees;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        }

        public void AddCustomer(int id)
         {
             MySqlConnection conn = DB.Connection();
             conn.Open();
             MySqlCommand cmd = new MySqlCommand("INSERT INTO customer_employee (customer_id, employee_id) VALUES (@customer_id, @employee_id);", conn);
             MySqlParameter prmEmployeeId = new MySqlParameter();
             prmEmployeeId.ParameterName = "@employee_id";
             prmEmployeeId.Value = Id;
             cmd.Parameters.Add(prmEmployeeId);
             MySqlParameter prmCustomerId = new MySqlParameter();
             prmCustomerId.ParameterName = "@customer_id";
             prmCustomerId.Value = id;
             cmd.Parameters.Add(prmCustomerId);
             cmd.ExecuteNonQuery();
             conn.Close();
             if(conn!=null)
             {
                 conn.Dispose();
             }
         }
         
         public void DeleteCustomer(int id)
         {
             MySqlConnection conn = DB.Connection();
             conn.Open();
             MySqlCommand cmd = new MySqlCommand("DELETE FROM customer_employee WHERE customer_id = @customer_id AND employee_id = @employee_id", conn);
             MySqlParameter prmCustomerId = new MySqlParameter();
             prmCustomerId.ParameterName = "@customer_id";
             prmCustomerId.Value = id;
             cmd.Parameters.Add(prmCustomerId);
             MySqlParameter prmEmployeeId = new MySqlParameter();
             prmEmployeeId.ParameterName = "@employee_id";
             prmEmployeeId.Value = Id;
             cmd.Parameters.Add(prmEmployeeId);
             cmd.ExecuteNonQuery();
             conn.Close();
             if(conn!=null)
             {
                 conn.Dispose();
             }
         }

         public void AddSpecialty(int id)
         {
             MySqlConnection conn = DB.Connection();
             conn.Open();
             MySqlCommand cmd = new MySqlCommand("INSERT INTO employee_specialty (specialty_id, employee_id) VALUES (@specialty_id, @employee_id);", conn);
             MySqlParameter specialtyId = new MySqlParameter();
             specialtyId.ParameterName = "@specialty_id";
             specialtyId.Value = id;
             cmd.Parameters.Add(specialtyId);
             MySqlParameter employeeId = new MySqlParameter();
             employeeId.ParameterName = "@employee_id";
             employeeId.Value = Id;
             cmd.Parameters.Add(employeeId);
             cmd.ExecuteNonQuery();
             conn.Close();
             if(conn!=null)
             {
                 conn.Dispose();
             }
         }
         
         public List<Specialty> GetAllSpecialties()
         {
             List<Specialty> allSpecialties = new List<Specialty>{};
             MySqlConnection conn = DB.Connection();
             conn.Open();
             MySqlCommand cmd = new MySqlCommand("SELECT specialties.* FROM employees JOIN employee_specialty es ON (employees.id = es.employee_id) JOIN specialties ON (specialties.id = es.specialty_id) WHERE employee_id = @employee_id;", conn);
             MySqlParameter prmId = new MySqlParameter();
             prmId.ParameterName = "@employee_id";
             prmId.Value = Id;
             cmd.Parameters.Add(prmId);
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
    }
}