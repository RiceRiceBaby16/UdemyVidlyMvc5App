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

        private List<Movie> GetMovies(bool includeGenre = true)
        {
            var query = _context.Movies.AsQueryable();
            if (includeGenre)
                query = query.Include(m => m.Genre);

            return query.ToList();
        }

        public ActionResult Details(int id)
        {
            Movie movie = GetMovieById(id);
            if (movie == null)
                return HttpNotFound();

            return View(CreateDetailsViewModel(movie));
        }

        private Movie GetMovieById(int id, bool includeGenre = true)
        {
            var query = _context.Movies.AsQueryable();
            if (includeGenre)
                query = query.Include(m => m.Genre);

            return query.SingleOrDefault(m => m.Id == id);
        }

        private MovieDetailsViewModel CreateDetailsViewModel(Movie movie)
        {
            return new MovieDetailsViewModel
            {
                DateAdded = movie.DateAdded.ToString("dd/MM/yyyy"),
                Genre = movie.Genre.Name,
                Name = movie.Name,
                NumberInStock = movie.NumberInStock,
                ReleaseDate = movie.ReleaseDate.ToString("dd/MM/yyyy")
            };
        }

        public ViewResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList(),
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var existingMovie = _context.Movies.Single(m => m.Id == movie.Id);
                AutoMapper.Mapper.Initialize(config => config.CreateMap<Movie, Movie>());
                AutoMapper.Mapper.Map(movie, existingMovie);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var existingMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (existingMovie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(existingMovie)
            {
                Genres = _context.Genres.AsEnumerable()
            };

            return View("MovieForm", viewModel);
        }
    }
}