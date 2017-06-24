using CourseByMosh.Models;
using CourseByMosh.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseByMosh.Controllers
{
    //[Route("customers")]
    public class CustomersController : Controller
    {
        private List<Customer> _customers;

        public CustomersController()
        {
            _customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "Josh Brookes"},
                new Customer{Id = 2, Name = "Andy Brookes"},
                new Customer{Id = 3, Name = "Clare Foster"}
            };
        }

        // GET: Customers
        //[Route("index")]
        public ActionResult Index()
        {
            return View(new CustomersViewModel { Customers = _customers });
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _customers.Find(c => c.Id == id);
            if (customer == null)
                return HttpNotFound("Customer not found");

            var detailsViewModel = new CustomerDetailsViewModel { Name = customer.Name };
            return View(detailsViewModel);
        }
    }
}