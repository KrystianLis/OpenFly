using Core.Entities;

namespace Core.Identity
{
    public class Address : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}