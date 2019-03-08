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
    }
}