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
            List<Customer> allCustomers = Customer.GetAll();
            List<Customer> specialtyCustomers = specialty.GetAllCustomers();
            List<Employee> allEmployees = Employee.GetAll();
            List<Employee> specialtyEmployees = specialty.GetAllEmployees();
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

        [HttpPost("/specialties/{specialtyId}/delete")]
        public ActionResult Delete(int specialtyId)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            specialty.Delete();
            return RedirectToAction("Index");
        }
        
        [HttpPost("/specialties/{specialtyId}/employees/new")]
        public ActionResult AddEmployee(int specialtyId, int employeeId)
        {
            Specialty.Find(specialtyId).AddEmployee(employeeId);
            return RedirectToAction("Show");
        }

        [HttpPost("/specialties/{specialtyId}/customers/new")]
        public ActionResult AddCustomer(int specialtyId, int employeeId)
        {
            Specialty.Find(specialtyId).AddEmployee(employeeId);
            return RedirectToAction("Show");
        }
    }
}