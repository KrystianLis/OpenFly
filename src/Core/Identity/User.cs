using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Core.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public IReadOnlyList<UserMeeting> UserMeeting { get; set; }
    }
}