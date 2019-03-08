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
        // [TestMethod]
        // public void GetAllCustomers_ReturnsEmptyList_EmptyList()
        // {
        //     List<Customer> emptyList = new List<Customer>{};
        //     List<Customer> testList = Customer.GetAllCustomers();
        //     CollectionAssert.AreEqual (emptyList, testList);
        // }
        // [TestMethod]
        // public void Save_AssignsCustomerIdToClientSide_True()
        // {
        //     Customer newCustomer = new Customer("John");
        //     newCustomer.Save();
        //     Customer testCustomer = Customer.GetAll()[0];
        // }
    }
}