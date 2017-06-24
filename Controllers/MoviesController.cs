#region Namespaces

using CourseByMosh.Models;
using CourseByMosh.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

#endregion Namespaces

namespace CourseByMosh.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
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
            return View(new MoviesViewModel { Movies = GetMovies() });
        }

        private List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }
    }
}