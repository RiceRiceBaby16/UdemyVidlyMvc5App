using System;
using System.ComponentModel.DataAnnotations;

namespace CourseByMosh.Models
{
    public class Movie
    {
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

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Number in stock")]
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Display(Name = "Date of release")]
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}