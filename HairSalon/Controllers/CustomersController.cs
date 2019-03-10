using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class CustomersController : Controller
    {
        [HttpGet("/customers")]
        public ActionResult Index()
        {
            List<Customer> allCustomers = Customer.GetAll();
            return View(allCustomers);
        }
        [HttpGet("/customers/new")]
        public ActionResult New()
        {
            return View();
        }

        // [HttpGet("/customers/{id}")]
        // public ActionResult Show(int employeeId, int id)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Employee searchedEmployee = Employee.Find(employeeId);
        //     Customer searchedCustomer = Customer.Find(id);
        //     model.Add("employee", searchedEmployee);
        //     model.Add("customer", searchedCustomer);
        //     return View(model);
        // }

        // [HttpGet("/customers/{id}/edit")]
        // public ActionResult Edit(int employeeId, int id)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Employee searchedEmployee = Employee.Find(employeeId);
        //     Customer searchedCustomer = Customer.Find(id);
        //     model.Add("employee", searchedEmployee);
        //     model.Add("customer", searchedCustomer);
        //     return View(model);
        // }

        // [HttpPost("/customers/{id}/update")]
        // public ActionResult Update(int id, int employeeId, string name)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Customer searchedCustomer = Customer.Find(id);
        //     searchedCustomer.Edit(name);
        //     Employee searchedEmployee = Employee.Find(employeeId);
        //     model.Add("employee", searchedEmployee);
        //     model.Add("customer", searchedCustomer);
        //     return View("Show", model);
        // }

        
        [HttpPost("/customers")]
        public ActionResult Create(string name)
        {
            Customer newCustomer = new Customer(name);
            newCustomer.Save();
            List<Customer> allCustomers = Customer.GetAll();
            return View("Index", allCustomers);
        }
    }
}