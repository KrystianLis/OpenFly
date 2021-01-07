using Core.Identity;

namespace Core.Entities
{
    public class UserMeeting
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}