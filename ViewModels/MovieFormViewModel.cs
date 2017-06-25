using CourseByMosh.Models;
using System.Collections.Generic;

namespace CourseByMosh.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}