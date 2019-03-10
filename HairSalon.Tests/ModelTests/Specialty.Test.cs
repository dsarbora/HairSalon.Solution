using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {

        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root; password=root;port=8889;database=dave_sarbora_test;";
        }
        public void Dispose()
        {
            Specialty.ClearAll();
            Customer.ClearAll();
            Employee.ClearAll();
        }

        [TestMethod]
        public void Save_SavesSpecialtyToDatabase_True()
        {
            Specialty newSpecialty = new Specialty("mullet");
            newSpecialty.Save();
            Specialty foundSpecialty = Specialty.GetAll()[0];
            Console.WriteLine("{0} {1}", newSpecialty.GetId(), foundSpecialty.GetId());
            Assert.AreEqual(newSpecialty, foundSpecialty);
        }
        [TestMethod]
        public void Find_FindsCorrectSpecialty_Specialty()
        {
            Specialty newSpecialty = new Specialty("mullet");
            Specialty otherSpecialty = new Specialty("buzz");
            newSpecialty.Save();
            otherSpecialty.Save();
            Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());
            Assert.AreEqual(newSpecialty, foundSpecialty);
        }
        [TestMethod]
        public void Delete_DeletesFromDatabase_EmptyList()
        {
            Specialty newSpecialty = new Specialty("mullet");
            newSpecialty.Save();
            newSpecialty.Delete();
            List<Specialty> manualList = new List<Specialty>{};
            List<Specialty> autoList = Specialty.GetAll();
            CollectionAssert.AreEqual(manualList, autoList);
        }
        [TestMethod]
        public void AddEmployee_AddsEmployee_EmployeeList()
        {
            Employee newEmployee = new Employee("Jill");
            Specialty newSpecialty = new Specialty("mullet");
            newEmployee.Save();
            newSpecialty.Save();
            newSpecialty.AddEmployee(newEmployee.GetId());
            List<Employee> specialtyEmployees = newSpecialty.GetAllEmployees();
            List<Employee> testList = new List<Employee>{newEmployee};
            CollectionAssert.AreEqual (testList, specialtyEmployees);
        }

        [TestMethod]
        public void GetAllEmployees_GetsEmployees_EmployeeList()
        {
            Employee Jill = new Employee("Jill");
            Employee Jack = new Employee("Jack");
            Jill.Save();
            Jack.Save();
            Specialty newSpecialty = new Specialty("mullet");
            newSpecialty.Save();
            newSpecialty.AddEmployee(Jill.GetId());
            newSpecialty.AddEmployee(Jack.GetId());
            List<Employee> testList = new List<Employee> {Jill, Jack};
            List<Employee> allList = newSpecialty.GetAllEmployees();
            Console.WriteLine("{0} {1}", testList.Count, allList.Count);
            CollectionAssert.AreEqual (testList, allList);
        }

        [TestMethod]
        public void AddCustomer_AddsCustomer_CustomerList()
        {
            Specialty mullet = new Specialty("mullet");
            mullet.Save();
            Customer John = new Customer("John");
            John.Save();
            mullet.AddCustomer(John.GetId());
            List<Customer> testList = mullet.GetAllCustomers();
            List<Customer> manualList = new List<Customer>{John};
            CollectionAssert.AreEqual (testList, manualList);
        }

        [TestMethod]
        public void GetAllCustomers_GetsAllCustomers_CustomerList()
        {
            Specialty buzz = new Specialty("buzz");
            buzz.Save();
            Customer John = new Customer("John");
            John.Save();
            Customer James = new Customer("James");
            James.Save();
            buzz.AddCustomer(John.GetId());
            buzz.AddCustomer(James.GetId());
            List<Customer> manualList = new List<Customer>{John, James};
            List<Customer> testList = buzz.GetAllCustomers();
            Console.WriteLine(manualList.Count+ " " + testList.Count);
            CollectionAssert.AreEqual(testList, manualList);
        }

        [TestMethod]
        public void Edit_ChangesName_True()
        {
            Specialty buzz = new Specialty("buzz");
            buzz.Save();
            buzz.EditName("crew cut");
            Specialty testSpecialty = Specialty.Find(buzz.GetId());
            Assert.AreEqual("crew cut", testSpecialty.GetName());
        }
    }
}