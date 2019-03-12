using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet("/employees")]
        public ActionResult Index()
        {
            return View(Employee.GetAll());
        }

        [HttpGet("employees/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/employees")]
        public ActionResult Create(string name)
        {
        Employee newEmployee = new Employee(name);
        newEmployee.Save();
        return RedirectToAction("Index");
        }

        [HttpGet("/employees/{id}")]
        public ActionResult Show(int id)
        {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Employee searchedEmployee = Employee.Find(id);
        List<Customer> allCustomers = Customer.GetAll();
        List<Specialty> allSpecialties = Specialty.GetAll();
        model["employee"] = searchedEmployee;
        model["allSpecialties"] = allSpecialties;
        model["allCustomers"] = allCustomers;
        model["employeeCustomers"] = searchedEmployee.GetAllCustomers();
        return View(model);
        }

        [HttpGet("/employees/{id}/edit")]
        public ActionResult Edit(int id)
        {
        Employee searchedEmployee = Employee.Find(id);
        return View(searchedEmployee);
        }

        [HttpPost("/employees/{id}")]
        public ActionResult Update(int id, string name)
        {
        Employee searchedEmployee = Employee.Find(id);
        searchedEmployee.Edit(name);
        return RedirectToAction("Show", id);
        }

        [HttpPost("/employees/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Employee.Find(id).Delete();
            return RedirectToAction("Index");
        }

        [HttpPost("/employees/{employeeId}/customers/new")]
        public ActionResult AddCustomer(int employeeId, int customerId)
        {
            Employee newEmployee = Employee.Find(employeeId);
            newEmployee.AddCustomer(customerId);
            return RedirectToAction("Show", new {id=employeeId});
        }

        [HttpPost("/employees/{employeeId}/specialties/new")]
        public ActionResult AddSpecialty(int employeeId, int specialtyId)
        {
            Employee.Find(employeeId).AddSpecialty(specialtyId);
            return RedirectToAction("Show", new {id=employeeId});
        }

    }
}
