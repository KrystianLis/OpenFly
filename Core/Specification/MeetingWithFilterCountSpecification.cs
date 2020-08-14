using Core.Entities;

namespace Core.Specification
{
    public class MeetingWithFilterCountSpecification : BaseSpecification<Meeting>
    {
        public MeetingWithFilterCountSpecification(MeetingSpecParams meetingParams)
            : base(x => (!meetingParams.TypeId.HasValue || x.MeetingTypeId == meetingParams.TypeId))
        {
            
        }
    }
}