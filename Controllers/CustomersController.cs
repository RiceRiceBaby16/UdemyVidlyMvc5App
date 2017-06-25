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

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = GetMembershipTypes()
            };
            return View("CustomerForm", viewModel);
        }

        private IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)// model binding
        {
            if (!ModelState.IsValid)// executes data annotations on the model
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = GetMembershipTypes()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var existingCustomer = _context.Customers.Single(c => c.Id == customer.Id);

                // Whitelist the properties than can be updated, but this is a security risk
                //TryUpdateModel(customer, "", new string[] { "Name", "Email" });

                // Set manually
                //existingCustomer.BirthDate = viewModel.Customer.BirthDate;
                //existingCustomer.IsSubscribedToNewsLetter = viewModel.Customer.IsSubscribedToNewsLetter;
                //existingCustomer.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                //existingCustomer.Name = viewModel.Customer.Name;
                
                // Or automatically map properties
                AutoMapper.Mapper.Initialize(config => config.CreateMap<Customer, Customer>());
                AutoMapper.Mapper.Map(customer, existingCustomer);// use AutoMapper to simplify setting properties on one object from another
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}