using Core.Entities;

namespace Core.Specification
{
    public class UserMeetingSpecification : BaseSpecification<UserMeeting>
    {
        public UserMeetingSpecification(string userId, int meetingId)
            : base(x => x.MeetingId == meetingId && Equals(x.UserId, userId))
        {
            AddInclude(x => x.Meeting);
            AddInclude(x => x.User);
        }
    }
}
