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

        [HttpGet("/customers/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Customer searchedCustomer = Customer.Find(id);
            List<Employee> customerEmployees = searchedCustomer.GetEmployees();
            List<Employee> allEmployees = Employee.GetAll();
            List<Specialty> allSpecialties = Specialty.GetAll();
            model.Add("customerEmployees", customerEmployees);
            model.Add("allSpecialties", allSpecialties);
            model.Add("allEmployees", allEmployees);
            model.Add("customer", searchedCustomer);
            return View(model);
        }

        [HttpGet("/customers/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Customer searchedCustomer = Customer.Find(id);
            model.Add("customer", searchedCustomer);
            return View(model);
        }

        [HttpPost("/customers/{id}/update")]
        public ActionResult Update(int id, string name)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Customer searchedCustomer = Customer.Find(id);
            searchedCustomer.Edit(name);
            model.Add("customer", searchedCustomer);
            return RedirectToAction("Show");
        }

        
        [HttpPost("/customers")]
        public ActionResult Create(string name)
        {
            Customer newCustomer = new Customer(name);
            newCustomer.Save();
            List<Customer> allCustomers = Customer.GetAll();
            return View("Index", allCustomers);
        }

        [HttpPost("/customers/{customerId}/employees/new")]
        public ActionResult AddEmployee(int customerId, int employeeId)
        {
            Customer customer = Customer.Find(customerId);
            Employee employee = Employee.Find(employeeId);
            customer.AddEmployee(employeeId);
            return RedirectToAction("Show", new {id=customerId});
        }
    }
}