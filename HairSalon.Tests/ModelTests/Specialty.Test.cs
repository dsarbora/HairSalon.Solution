using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            DBConfiguration.ConnectionString = "server=localhost;user id=root; password=root;port=8889;database=first_last_test;";
        }
        public void Dispose()
        {
            Specialty.ClearAll();
            Customer.ClearAll();
            Employee.ClearAll();
        }

        [TestMethod]
        public void Save_SavesSpecialtyToDatabase()
        {
            Specialty newSpecialty = new Specialty("Mullet");
            newSpecialty.Save();
            Specialty foundSpecialty = Specialty.GetAll()[0];
            Assert.AreEqual(newSpecialty, foundSpecialty);
        }
    }
}