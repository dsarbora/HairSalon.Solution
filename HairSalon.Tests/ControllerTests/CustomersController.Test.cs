using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalonControllers.Tests
{
    [TestClass]
    public class CustomersControllerTest : IDisposable
    {
        public void Dispose()
        {
            Employee.ClearAll();
            Customer.ClearAll();
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            CustomersController controller = new CustomersController();
            ViewResult newView = controller.New() as ViewResult;
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }
        [TestMethod]
        public void Show_HasCorrectModelType_True()
        {
            Customer newCustomer = new Customer("John");
            newCustomer.Save();
            CustomersController controller = new CustomersController();
            ViewResult showView = controller.Show(newCustomer.GetId()) as ViewResult;
            var result = showView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }
        [TestMethod]
        public void Edit_HasCorrectModelType_True()
        {
            
            Customer newCustomer = new Customer("John");
            newCustomer.Save();
            int id = newCustomer.GetId();
            CustomersController controller = new CustomersController();
            ViewResult showView = controller.Show(id) as ViewResult;
            var result = showView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }
        [TestMethod]
        public void Index_HasCorrectModelType_CustomerList()
        {
            CustomersController controller = new CustomersController();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Customer>));
        }
    }
}