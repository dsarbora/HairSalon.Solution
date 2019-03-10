using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Customer
    {
        int Id;
        string Name;

        public Customer(string name, int id=0)
        {
            Name=name;
            Id=id;
        }

        public string GetName()
        {return Name;}

        public int GetId()
        {return Id;}

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO customers (name) VALUES (@name);";
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

        public void Edit(string name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE customers SET name=@name WHERE id=@id;";
            MySqlParameter prmName = new MySqlParameter();
            prmName.ParameterName = "@name";
            prmName.Value = name;
            cmd.Parameters.Add(prmName);
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@id";
            prmId.Value = Id;
            cmd.Parameters.Add(prmId);
            cmd.ExecuteNonQuery();
            Name = name;
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText= @"DELETE FROM customers WHERE id = @id; DELETE FROM customer_employee WHERE customer_id = @id; DELETE FROM customer_specialty WHERE customer_id = @id";
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

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM customers; DELETE FROM customer_employee; DELETE FROM customer_specialty";
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherCustomer)
        {
            if(!(otherCustomer is Customer))
            return false;

            else
            {
                Customer newCustomer = (Customer)otherCustomer;
                bool nameEquality = this.GetName().Equals(newCustomer.GetName());
                bool idEquality = this.GetId().Equals(newCustomer.GetId());
                return (nameEquality && idEquality);
            }
        }

        public static Customer Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM customers WHERE id=@id;";
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@id";
            prmId.Value = id;
            cmd.Parameters.Add(prmId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            string name = "";
            while(rdr.Read())
            {
                name = rdr.GetString(1);
            }
            Customer newCustomer = new Customer(name, id);
            conn.Close();
            if (conn!=null)
            {
                conn.Dispose();
            }
            return newCustomer;
        }

        public static List<Customer> GetAll()
        {
            List<Customer> allCustomers = new List<Customer>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM customers", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Customer newCustomer = new Customer(name, id);
                allCustomers.Add(newCustomer);
            }
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return allCustomers;
        }

        public void AddEmployee(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO customer_employee (customer_id, employee_id) VALUES (@customer_id, @employee_id);", conn);
            MySqlParameter prmCustomerId = new MySqlParameter();
            prmCustomerId.ParameterName = "@customer_id";
            prmCustomerId.Value = Id;
            cmd.Parameters.Add(prmCustomerId);
            MySqlParameter prmEmployeeId = new MySqlParameter();
            prmEmployeeId.ParameterName = "@employee_id";
            prmEmployeeId.Value = id;
            cmd.Parameters.Add(prmEmployeeId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        } 

        public List<Employee> GetEmployees()
        {
            List<Employee> allEmployees = new List<Employee>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT employees.* FROM customers JOIN customer_employee ce ON (customers.id=ce.customer_id) JOIN employees ON (employees.id=ce.employee_id) WHERE customers.id = @id;", conn);
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@id";
            prmId.Value = Id;
            cmd.Parameters.Add(prmId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Employee addedEmployee = new Employee(name, id);
                allEmployees.Add(addedEmployee);
            }
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return allEmployees;
        }
        
        public void DeleteEmployee(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM customer_employee WHERE customer_id = @customer_id AND employee_id = @employee_id", conn);
            MySqlParameter prmCustomerId = new MySqlParameter();
            prmCustomerId.ParameterName = "@customer_id";
            prmCustomerId.Value = Id;
            cmd.Parameters.Add(prmCustomerId);
            MySqlParameter prmEmployeeId = new MySqlParameter();
            prmEmployeeId.ParameterName = "@employee_id";
            prmEmployeeId.Value = id;
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
            MySqlCommand cmd = new MySqlCommand("UPDATE customer_specialty SET current = @false WHERE customer_id = @customer_id; INSERT INTO customer_specialty (customer_id, current, specialty_id) VALUES (@customer_id, @true, @specialty_id);", conn);
            MySqlParameter prmCustomerId = new MySqlParameter();
            prmCustomerId.ParameterName = "@customer_id";
            prmCustomerId.Value = Id;
            cmd.Parameters.Add(prmCustomerId);
            MySqlParameter prmSpecialtyId = new MySqlParameter();
            prmSpecialtyId.ParameterName = "@specialty_id";
            prmSpecialtyId.Value = id;
            cmd.Parameters.Add(prmSpecialtyId);
            MySqlParameter prmFalse = new MySqlParameter();
            prmFalse.ParameterName = "@false";
            prmFalse.Value = false;
            cmd.Parameters.Add(prmFalse);
            MySqlParameter prmTrue = new MySqlParameter();
            prmTrue.ParameterName = "@true";
            prmTrue.Value = true;
            cmd.Parameters.Add(prmTrue);
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        }

        public void DeleteSpecialty(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM customer_specialty WHERE customer_id=@customer_id AND specialty_id = @specialty_id;", conn);
            MySqlParameter prmCustomerId = new MySqlParameter();
            prmCustomerId.ParameterName = "@customer_id";
            prmCustomerId.Value = Id;
            cmd.Parameters.Add(prmCustomerId);
            MySqlParameter prmSpecialtyId = new MySqlParameter();
            prmSpecialtyId.ParameterName = "@specialty_id";
            prmSpecialtyId.Value = id;
            cmd.Parameters.Add(prmSpecialtyId);
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
            MySqlCommand cmd = new MySqlCommand("SELECT specialties.* FROM customers JOIN customer_specialty cs ON (customers.id = cs.customer_id) JOIN specialties ON (specialties.id = cs.specialty_id) WHERE customers.id = @customer_id;", conn);
            MySqlParameter prmCustomerId = new MySqlParameter();
            prmCustomerId.ParameterName = "@customer_id";
            prmCustomerId.Value = Id;
            cmd.Parameters.Add(prmCustomerId);
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

        public Specialty GetCurrentHairCut()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT specialties.* FROM customers JOIN customer_specialty cs ON (customers.id = cs.customer_id) JOIN specialties ON (specialties.id = cs.specialty_id) WHERE customer_id = @customer_id AND current = @true;", conn);
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@customer_id";
            prmId.Value = Id;
            cmd.Parameters.Add(prmId);
            MySqlParameter prmCurrent = new MySqlParameter();
            prmCurrent.ParameterName="@true";
            prmCurrent.Value=true;
            cmd.Parameters.Add(prmCurrent);
            MySqlDataReader rdr = cmd.ExecuteReader();
            string name="";
            int id=0;
            if(rdr.Read())
            {
                name=rdr.GetString(1);
                id=rdr.GetInt32(0);
            }
            Specialty currentSpecialty = new Specialty(name, id);
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return currentSpecialty;
        }
    }



}