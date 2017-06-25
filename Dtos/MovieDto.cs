using System;
using System.ComponentModel.DataAnnotations;

namespace CourseByMosh.Dtos
{
    public class MovieDto
    {
        public DateTime DateAdded { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}