using CourseByMosh.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourseByMosh.Dtos
{
    public class CustomerDto
    {
        [Min18YearIfAMember]
        public DateTime? BirthDate { get; set; }

        public int Id { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
    }
}