using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
    [TestClass]
    public class EmployeeTest : IDisposable
    {
        public EmployeeTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root; password=root;port=8889;database=dave_sarbora_test;";
        }

        public void Dispose()
        {
            Employee.ClearAll();
            Customer.ClearAll();
        }

        // [TestMethod]
        // public void EmployeeConstructor_CanCreateInstanceOfEmployee_True()
        // {
        //     Employee newEmployee = new Employee("Joe");
        //     Assert.AreEqual(typeof(Employee), newEmployee.GetType());
        // }

        // [TestMethod]
        // public void GetName_ReturnsEmployeeName_String()
        // {
        //     string newString="Joe";
        //     Employee newEmployee = new Employee(newString);
        //     Assert.AreEqual(newEmployee.GetName(), newString);
        // }

        // [TestMethod]
        // public void GetAll_ReturnsAllEmployees_EmployeeList()
        // {
        //     Employee newEmployee1 = new Employee("Jack");
        //     Employee newEmployee2 = new Employee("Jill");
        //     newEmployee1.Save();
        //     newEmployee2.Save();
        //     List<Employee> manualList = new List<Employee>{newEmployee1, newEmployee2};
        //     List<Employee> autoList = Employee.GetAll();
        //     CollectionAssert.AreEqual (manualList, autoList);
        // }

        // [TestMethod]
        // public void Find_ReturnsCorrectEmployee_Employee()
        // {
        //     Employee newEmployee1 = new Employee("Jack");
        //     Employee newEmployee2 = new Employee("Jill");
        //     newEmployee1.Save();
        //     newEmployee2.Save();
        //     Employee foundEmployee = Employee.Find(newEmployee1.GetId());
        //     Assert.AreEqual(foundEmployee, newEmployee1);
        // }

        // [TestMethod]
        // public void GetAllCustomers_ReturnsAllCustomersForEmployee_Customer()
        // {
        //     Employee newEmployee = new Employee("Joe");
        //     newEmployee.Save();
        //     Customer newCustomer = new Customer("Jack");
        //     Customer newCustomer2 = new Customer("Bill");
        //     newCustomer.Save();
        //     newCustomer2.Save();
        //     List<Customer> manualList = new List<Customer>{newCustomer, newCustomer2};
        //     List<Customer> autoList = newEmployee.GetAllCustomers();
        //     CollectionAssert.AreEqual (manualList, autoList);
        //  }
         
        //  [TestMethod]
        //  public void Equals_ReturnsTrueIfNamesAreSame_True()
        //  {
        //      Employee newEmployee = new Employee("Joe");
        //      Employee testEmployee = new Employee("Joe");
        //      Assert.AreEqual (newEmployee, testEmployee);
        //  }

        //  [TestMethod]
        //  public void Save_AssignsEmployeeId_Id()
        //  {
        //      Employee newEmployee = new Employee("Joe");
        //      newEmployee.Save();
        //      Employee savedEmployee = Employee.GetAll()[0];
        //      int result = newEmployee.GetId();
        //      int testId = savedEmployee.GetId();
        //      Assert.AreEqual (result, testId);
        //  }
    }
}