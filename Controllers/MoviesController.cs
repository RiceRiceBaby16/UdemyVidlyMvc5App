using CourseByMosh.Models;
using CourseByMosh.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseByMosh.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> _movies;

        public MoviesController()
        {
            _movies = new List<Movie>
            {
                //new Movie{Name = "Shrek"},
                //new Movie{Name = "Wall-e"}
            };
        }

        public ActionResult Index()
        {
            var moviesViewModel = new MoviesViewModel { Movies = _movies };
            return View(moviesViewModel);
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            //ViewData["Movie"] = movie;//dynamic = pain!
            //ViewBag.Movie = movie;//dynamic = pain!
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };
            return View(viewModel);// strongly-typed = Yay! :-)

            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });
            //return HttpNotFound();
            //return new ContentResult("Hi"); => return Content();
            //return new PartialViewResult(); => return PartialView();
            //return new RedirectResult("url"); => return RedirectResult("url");
            //return new RedirectToRouteResult("routeName", new System.Web.Routing.RouteValueDictionary(new Dictionary<string, object>())); =>
            //return RedirectToRoute(...);
            //return new JsonResult(); => return Json();
            //return new FileResult(); => return File();
            //return new HttpNotFoundResult(); => return HttpNotFound();
            //return new EmptyResult();
            //return new ViewResult(); => View
            //return View(new Movie { Name = "Shrek!" });
        }

        // The below is attribute routing
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]// define constraints.
        //*** OTHER CONSTRAINTS: min, max, minlength, maxlength, int, float, guid
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}