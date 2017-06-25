using System;
using System.ComponentModel.DataAnnotations;

namespace CourseByMosh.Models
{
    public class Movie
    {
        public DateTime DateAdded { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int NumberInStock { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}