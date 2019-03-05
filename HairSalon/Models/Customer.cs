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
                    MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO customers (name, employee_id) VALUES (@name, @employee_id);";
            MySqlParameter prmName = new MySqlParameter();
            prmName.ParameterName = "@name";
            prmName.Value = Name;
            cmd.Parameters.Add(prmName);
            MySqlParameter employeeId = new MySqlParameter();
            employeeId.ParameterName = "@employee_id";
            employeeId.Value = EmployeeId;
            cmd.Parameters.Add(employeeId);
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
            cmd.CommandText= @"DELETE FROM customers WHERE id = @id;";
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
            cmd.CommandText = @"DELETE FROM customers;";
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
                bool employeeIdEquality = this.GetEmployeeId().Equals(newCustomer.GetEmployeeId());
                return (nameEquality && idEquality && employeeIdEquality);
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
            int employeeId = 0;
            while(rdr.Read())
            {
                name = rdr.GetString(1);
                employeeId = rdr.GetInt32(2);
            }
            Customer newCustomer = new Customer(name, employeeId, id);
            conn.Close();
            if (conn!=null)
            {
                conn.Dispose();
            }
            return newCustomer;
        }
    }

}