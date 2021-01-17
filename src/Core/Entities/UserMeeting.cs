using Core.Entities.Identity;

namespace Core.Entities
{
    public class UserMeeting : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}