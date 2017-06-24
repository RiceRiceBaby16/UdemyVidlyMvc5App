using CourseByMosh.Models;
using CourseByMosh.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
            return View(new CustomersViewModel { Customers = _context.Customers.Include(c => c.MembershipType).ToList() });
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound("Customer not found");

            return View(new CustomerDetailsViewModel { Name = customer.Name });
        }
    }
}