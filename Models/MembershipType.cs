namespace CourseByMosh.Models
{
    public class MembershipType
    {
        public byte DiscountRate { get; set; }
        public byte DurationInMonths { get; set; }
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
    }
}