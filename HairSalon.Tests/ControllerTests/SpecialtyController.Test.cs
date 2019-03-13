using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtiesControllerTest : IDisposable
    {
        public void Dispose()
        {
            Specialty.ClearAll();
            Employee.ClearAll();
            Customer.ClearAll();
        }

        [TestMethod]
        public void Index_HasCorrectModelType_SpecialtyList()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Specialty>));
        }
        [TestMethod]
        public void New_ReturnsCorrectView_ViewResult()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ViewResult indexView = controller.Index() as ViewResult;
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
        [TestMethod]
        public void Edit_HasCorrectModelType()
        {
            SpecialtiesController controller = new SpecialtiesController();
            Specialty newSpecialty = new Specialty("buzzcut");
            newSpecialty.Save();
            ViewResult editView = controller.Edit(newSpecialty.GetId()) as ViewResult;
            var result = editView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Specialty));

        }
        [TestMethod]
        public void Show_HasCorrectModelType()
        {
            SpecialtiesController controller = new SpecialtiesController();
            Specialty specialty = new Specialty("buzz");
            ViewResult showView = controller.Show(specialty.GetId()) as ViewResult;
            var result = showView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

    }
}