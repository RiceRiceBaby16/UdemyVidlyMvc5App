using CourseByMosh.Models;
using System.Collections.Generic;

namespace CourseByMosh.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}