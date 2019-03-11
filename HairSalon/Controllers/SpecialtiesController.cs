using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpGet("/specialties/new")]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost("/specialties")]
        public ActionResult Create(string name)
        {
            Specialty specialty = new Specialty(name);
            specialty.Save();
            return RedirectToAction("Index");
        }
        
        [HttpGet("/specialties/{specialtyId}")]
        public ActionResult Show(int specialtyId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty specialty = Specialty.Find(specialtyId);
            List<Customer> allCustomers = new List<Customer>();
            List<Customer> specialtyCustomers = new List<Customer>();
            List<Employee> allEmployees = new List<Employee>();
            List<Employee> specialtyEmployees = new List<Employee>();
            model.Add("specialty", specialty);
            model.Add("allEmployees", allEmployees);
            model.Add("specialtyEmployees", specialtyEmployees);
            model.Add("allCustomers", allCustomers);
            model.Add("specialtyCustomers", specialtyCustomers);
            return View(model);
        }

        [HttpGet("/specialties/{specialtyId}/edit")]
        public ActionResult Edit(int specialtyId)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            return View(specialty);
        }


        [HttpPost("/specialties/{specialtyId}/update")]
        public ActionResult Update(string name, int specialtyId)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            specialty.EditName(name);
            return RedirectToAction("Show", specialtyId);
        }
    }
}