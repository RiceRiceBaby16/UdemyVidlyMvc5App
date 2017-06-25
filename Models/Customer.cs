using System;
using System.ComponentModel.DataAnnotations;

namespace CourseByMosh.Models
{
    public class Customer
    {
        [Display(Name = "Date of birth")]
        public DateTime? BirthDate { get; set; }

        public int Id { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}