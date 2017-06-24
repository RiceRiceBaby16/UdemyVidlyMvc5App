#region Namespaces

using CourseByMosh.Models;
using CourseByMosh.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

#endregion Namespaces

namespace CourseByMosh.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (_context != null)
                _context.Dispose();
        }

        public ActionResult Index()
        {
            return View(new CustomersViewModel { Customers = GetCustomers() });
        }

        private List<Customer> GetCustomers(bool includeMembershipType = true)
        {
            var query = _context.Customers.AsQueryable();
            if (includeMembershipType)
                query = query.Include(c => c.MembershipType);

            return query.ToList();
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            Customer customer = GetCustomerById(id);
            if (customer == null)
                return HttpNotFound("Customer not found");

            return View(CreateDetailsViewModel(customer));
        }

        private Customer GetCustomerById(int id, bool includeMembershipType = true)
        {
            var query = _context.Customers.AsQueryable();
            if (includeMembershipType)
                query = query.Include(c => c.MembershipType);

            return query.SingleOrDefault(c => c.Id == id);
        }

        private CustomerDetailsViewModel CreateDetailsViewModel(Customer customer)
        {
            return new CustomerDetailsViewModel
            {
                BirthDate = GetBirthDateString(customer.BirthDate),
                MembershipType = customer.MembershipType.Name,
                Name = customer.Name
            };
        }

        private string GetBirthDateString(DateTime? birthDate)
        {
            return birthDate.HasValue ? birthDate.Value.ToString("dd/MM/yyyy") : string.Empty;
        }
    }
}