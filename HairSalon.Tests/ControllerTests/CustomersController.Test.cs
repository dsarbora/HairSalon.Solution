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
        public void New_HasCorrectModelType_True()
        {
            Employee newEmployee = new Employee("Jane");
            newEmployee.Save();
            int id = newEmployee.GetId();
            CustomersController controller = new CustomersController();
            ViewResult newView = controller.New(id) as ViewResult;
            var result = newView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Employee));
        }
        [TestMethod]
        public void Show_HasCorrectModelType_True()
        {
            Employee newEmployee = new Employee("Jane");
            newEmployee.Save();
            int employeeId = newEmployee.GetId();
            Customer newCustomer = new Customer("John", employeeId);
            newCustomer.Save();
            int id = newCustomer.GetId();
            CustomersController controller = new CustomersController();
            ViewResult showView = controller.Show(employeeId, id) as ViewResult;
            var result = showView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }
        // [TestMethod]
        // public void Edit_HasCorrectModelType_True()
        // {
        //     Employee newEmployee = new Employee("Jane");
        //     newEmployee.Save();
        //     int employeeId = newEmployee.GetId();
        //     Customer newCustomer = new Customer("John", employeeId);
        //     newCustomer.Save();
        //     int id = newCustomer.GetId();
        //     CustomersController controller = new CustomersController();
        //     ViewResult showView = controller.Show(id, employeeId) as ViewResult;
        //     var result = showView.ViewData.Model;
        //     Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        // }
    }
}