using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MySql.Data.MySqlClient;
using HairSalon.Models;


namespace HairSalon.Tests
{
    [TestClass]
    public class CustomerTest : IDisposable
    {
        public CustomerTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root; password=root;port=8889;database=dave_sarbora_test;";
        }

        public void Dispose()
        {
            Customer.ClearAll();
            Specialty.ClearAll();
            Employee.ClearAll();
        }

        [TestMethod]
        public void CustomerConstructor_CreatesCustomer_True()
        {
            Customer newCustomer = new Customer("John");
            Assert.AreEqual(typeof(Customer), newCustomer.GetType());
        }
        [TestMethod]
        public void GetName_ReturnsCustomerName_String()
        {
            Customer newCustomer = new Customer("John");
            Assert.AreEqual ("John", newCustomer.GetName());
        }
        [TestMethod]
        public void GetAll_ReturnsAllCustomers_CustomerList()
        {
            Customer John = new Customer("John");
            John.Save();
            Customer Jack = new Customer("Jack");
            Jack.Save();
            List<Customer> emptyList = new List<Customer>{John, Jack};
            List<Customer> testList = Customer.GetAll();
            CollectionAssert.AreEqual (emptyList, testList);
        }
        // [TestMethod]
        // public void Save_AssignsCustomerIdToClientSide_True()
        // {
        //     Customer newCustomer = new Customer("John");
        //     newCustomer.Save();
        //     Customer testCustomer = Customer.GetAll()[0];
        // }
        [TestMethod]
        public void AddEmployee_AddsEmployeeToCustomer_EmployeeList()
        {
            Customer John = new Customer("John");
            John.Save();
            Employee Jack = new Employee("Jack");
            Jack.Save();
            John.AddEmployee(Jack.GetId());
            List<Employee> testList = John.GetEmployees();
            List<Employee> manualList = new List<Employee>{Jack};
            CollectionAssert.AreEqual (testList, manualList);

        }

        [TestMethod]
        public void GetEmployees_GetsAllEmployees_True()
        {
            Customer John = new Customer("John");
            John.Save();
            Employee Jack = new Employee("Jack");
            Jack.Save();
            John.AddEmployee(Jack.GetId());
            Employee Jill = new Employee("Jill");
            Jill.Save();
            John.AddEmployee(Jill.GetId());
            List<Employee> testList = John.GetEmployees();
            List<Employee> manualList = new List<Employee>{Jack, Jill};
            CollectionAssert.AreEqual (testList, manualList);
        }
        [TestMethod]
        public void DeleteEmployee_DeletesEmployee_EmployeeList()
        {
            Customer john = new Customer("John");
            john.Save();
            Employee jack = new Employee("Jack");
            jack.Save();
            john.AddEmployee(jack.GetId());
            john.DeleteEmployee(jack.GetId());
            List<Employee> testList = new List<Employee>{};
            List<Employee> autoList = john.GetEmployees();
            CollectionAssert.AreEqual(testList, autoList);
        }

        [TestMethod]
        public void AddSpecialty_AddsSpecialty_SpecialtyList()
        {
            Customer john = new Customer("John");
            john.Save();
            Specialty buzz = new Specialty("buzz");
            buzz.Save();
            john.AddSpecialty(buzz.GetId());
            List<Specialty> testList = new List<Specialty>{buzz};
            List<Specialty> autoList = john.GetAllSpecialties();
            CollectionAssert.AreEqual(testList, autoList);
        }

        [TestMethod]
        public void GetSpecialties_GetsAllSpecialties_SpecialtyList()
        {
            Customer newCustomer = new Customer("John");
            newCustomer.Save();
            Specialty newSpecialty = new Specialty("buzz");
            Specialty newSpecialty2 = new Specialty("mullet");
            newSpecialty.Save();
            newSpecialty2.Save();
            newCustomer.AddSpecialty(newSpecialty.GetId());
            newCustomer.AddSpecialty(newSpecialty2.GetId());
            List<Specialty> allSpecialties = new List<Specialty>{newSpecialty, newSpecialty2};
            List<Specialty> testList = newCustomer.GetAllSpecialties();
            CollectionAssert.AreEqual(allSpecialties, testList);
        }
        [TestMethod]
        public void DeleteSpecialty_DeletesSpecialtyFromDatabase_SpecialtyList()
        {
            Customer newCustomer = new Customer("John");
            newCustomer.Save();
            Specialty newSpecialty = new Specialty("buzz");
            newSpecialty.Save();
            newCustomer.AddSpecialty(newSpecialty.GetId());
            newCustomer.DeleteSpecialty(newSpecialty.GetId());
            List<Specialty> allSpecialties = new List<Specialty>{};
            List<Specialty> testList = newCustomer.GetAllSpecialties();
            CollectionAssert.AreEqual(allSpecialties, testList);
        }

        [TestMethod]
        public void AddSpecialty_SetsCurrentHairCut_True()
        {
            Customer newCustomer = new Customer("Jack");
            newCustomer.Save();
            Specialty newSpecialty = new Specialty("mullet");
            Specialty newSpecialty2 = new Specialty("buzz");
            newSpecialty.Save();
            newSpecialty2.Save();
            newCustomer.AddSpecialty(newSpecialty.GetId());
            newCustomer.AddSpecialty(newSpecialty2.GetId());
            Specialty foundSpecialty = newCustomer.GetCurrentHairCut();
            Assert.AreEqual(newSpecialty2.GetName(), foundSpecialty.GetName());
        }

                [TestMethod]
        public void AddSpecialty_SetsLastHairCutToFalse_False()
        {
            Customer newCustomer = new Customer("Jack");
            newCustomer.Save();
            Specialty newSpecialty = new Specialty("mullet");
            Specialty newSpecialty2 = new Specialty("buzz");
            newSpecialty.Save();
            newSpecialty2.Save();
            newCustomer.AddSpecialty(newSpecialty2.GetId());
            newCustomer.AddSpecialty(newSpecialty.GetId());
            Specialty foundSpecialty = newCustomer.GetCurrentHairCut();
            Assert.AreNotEqual(newSpecialty2.GetName(), foundSpecialty.GetName());
        }
    }
}