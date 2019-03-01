using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class CustomersController : Controller
    {
        [HttpGet("/employees/{id}/customers/new")]
        public ActionResult New(int id)
        {
            Employee searchedEmployee = Employee.Find(id);
            return View(searchedEmployee);
        }

        [HttpGet("/employees/{employeeId}/customers/{id}")]
        public ActionResult Show(int employeeId, int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Employee searchedEmployee = Employee.Find(employeeId);
            Customer searchedCustomer = Customer.Find(id);
            model.Add("employee", searchedEmployee);
            model.Add("customer", searchedCustomer);
            return View(model);
        }

        [HttpGet("/employees/{employeeId}/customers/{id}/edit")]
        public ActionResult Edit(int id, int employeeId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Employee searchedEmployee = Employee.Find(employeeId);
            Customer searchedCustomer = Customer.Find(id);
            model.Add("employee", searchedEmployee);
            model.Add("customer", searchedCustomer);
            return View(model);
        }

        [HttpPost("/employees/{employeeId}/customers/{id}")]
        public ActionResult Update(int id, int employeeId, string name)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Customer searchedCustomer = Customer.Find(id);
            searchedCustomer.Edit(name);
            Employee searchedEmployee = Employee.Find(employeeId);
            model.Add("employee", searchedEmployee);
            model.Add("customer", searchedCustomer);
            return View("Show", model);
        }
    }
}