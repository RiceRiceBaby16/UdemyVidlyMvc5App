using System.ComponentModel.DataAnnotations;

namespace CourseByMosh.Models
{
    public class Movie
    {
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}