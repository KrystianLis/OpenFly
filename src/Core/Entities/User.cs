using System.Collections.Generic;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }      
        public IReadOnlyList<UserMeeting> UserMeeting { get; set; }
    }
}