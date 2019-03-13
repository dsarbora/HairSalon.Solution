using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class EmployeesControllerTest : IDisposable
    {

        public void Dispose()
        {
            Employee.ClearAll();
            Customer.ClearAll();
        }
        [TestMethod]
        public void Index_ReturnsCorrectViewType_True()
        {
            EmployeesController controller = new EmployeesController();
            ActionResult indexView = controller.Index();
            Assert.AreEqual(indexView.GetType(), typeof(ViewResult));
        }
        [TestMethod]
        public void Index_HasCorrectModel_True()
        {
            EmployeesController controller = new EmployeesController();
            ViewResult indexView=controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Employee>));
        }
        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            EmployeesController controller = new EmployeesController();
            ActionResult newView = controller.New();
            Assert.AreEqual(newView.GetType(), typeof(ViewResult));
        }
        [TestMethod]
        public void Show_HastCorrectModel_True()
        {
            Employee newEmployee = new Employee("Jackson");
            newEmployee.Save();
            int id = newEmployee.GetId();
            EmployeesController controller=new EmployeesController();
            ViewResult showView=controller.Show(id) as ViewResult;
            var result = showView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));

        }
        [TestMethod]
        public void Edit_HasCorrectModel_True()
        {
            Employee newEmployee = new Employee("Jill");
            newEmployee.Save();
            int id = newEmployee.GetId();
            EmployeesController controller=new EmployeesController();
            ViewResult editView=controller.Edit(id) as ViewResult;
            var result = editView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Employee));

        }
    }
}