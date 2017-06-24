using System.ComponentModel.DataAnnotations;

namespace CourseByMosh.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}