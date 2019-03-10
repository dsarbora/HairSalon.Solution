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
            MySqlCommand cmd = new MySqlCommand("DELETE FROM specialties; DELETE FROM employee_specialty; DELETE FROM customer_specialty;", conn);
            cmd.ExecuteNonQuery();
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
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM specialties WHERE id = @id;", conn);
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

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM specialties WHERE id = @id; DELETE FROM employee_specialty WHERE specialty_id = @id;", conn);
            MySqlParameter prmId= new MySqlParameter();
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

        public void AddEmployee(int employeeId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO employee_specialty (employee_id, specialty_id) VALUES (@employee_id, @specialty_id);", conn);
            MySqlParameter prmEmployeeId = new MySqlParameter();
            prmEmployeeId.ParameterName = "@employee_id";
            prmEmployeeId.Value = employeeId;
            cmd.Parameters.Add(prmEmployeeId);
            MySqlParameter prmSpecialtyId = new MySqlParameter();
            prmSpecialtyId.ParameterName = "@specialty_id";
            prmSpecialtyId.Value = Id;
            cmd.Parameters.Add(prmSpecialtyId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT employees.* FROM specialties JOIN employee_specialty es ON (specialties.id=es.specialty_id) JOIN employees ON (employees.id = es.employee_id) WHERE specialty_id = @specialty_id;", conn);
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@specialty_id";
            prmId.Value = Id;
            cmd.Parameters.Add(prmId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                string name = rdr.GetString(1);
                int id = rdr.GetInt32(0);
                Employee newEmployee = new Employee(name, id);
                employeeList.Add(newEmployee);
            }

            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
            return employeeList;
        }

        public void AddCustomer(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO customer_specialty (customer_id, specialty_id) VALUES (@customer_id, @specialty_id);", conn);
            MySqlParameter customerId = new MySqlParameter();
            customerId.ParameterName = "@customer_id";
            customerId.Value = id;
            cmd.Parameters.Add(customerId);
            MySqlParameter specialtyId = new MySqlParameter();
            specialtyId.ParameterName = "@specialty_id";
            specialtyId.Value = Id;
            cmd.Parameters.Add(specialtyId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!=null)
            {
                conn.Dispose();
            }
         
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> allCustomers = new List<Customer>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT customers.* FROM specialties JOIN customer_specialty cs ON (specialties.id = cs.specialty_id) JOIN customers ON (customers.id=cs.customer_id) WHERE specialty_id = @specialty_id;", conn);
            MySqlParameter prmId = new MySqlParameter();
            prmId.ParameterName = "@specialty_id";
            prmId.Value = Id;
            cmd.Parameters.Add(prmId);
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

        public void EditName(string name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE specialties SET name=@name WHERE id=@id", conn);
            MySqlParameter prmName = new MySqlParameter();
            prmName.ParameterName = "@name";
            prmName.Value = name;
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

        public void DeleteEmployee()
        {

        }

        public void DeleteCustomer()
        {

        }

        public override bool Equals(System.Object otherSpecialty)
        {
            if(!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool idEquality = this.Id.Equals(newSpecialty.GetId());
                bool nameEquality = this.Name.Equals(newSpecialty.GetName());
                return (idEquality && nameEquality);
            }
        }
    }
}