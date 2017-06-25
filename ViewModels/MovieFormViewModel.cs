using CourseByMosh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseByMosh.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        private DateTime _dateAdded = DateTime.Now;
        public DateTime DateAdded
        {
            get
            {
                return _dateAdded;
            }
            set
            {
                _dateAdded = value;
            }
        }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Number in stock")]
        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        [Display(Name = "Date of release")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        public string Title
        {
            get
            {
                return Id == null ? "New Movie" : "Edit Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            GenreId = movie.GenreId;
            Id = movie.Id;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
        }
    }
}