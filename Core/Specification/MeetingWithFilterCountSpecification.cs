using Core.Entities;

namespace Core.Specification
{
    public class MeetingWithFilterCountSpecification : BaseSpecification<Meeting>
    {
        public MeetingWithFilterCountSpecification(MeetingSpecParams meetingParams)
            : base(x => 
                (string.IsNullOrEmpty(meetingParams.Search) || x.Name.ToLower().Contains(meetingParams.Search)) &&
                (!meetingParams.TypeId.HasValue || x.MeetingTypeId == meetingParams.TypeId))
        {
        }
    }
}