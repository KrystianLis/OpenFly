using Core.Entities;

namespace Core.Specification
{
    public class MeetingsWithTypesSpecification : BaseSpecification<Meeting>
    {
        public MeetingsWithTypesSpecification()
        {
            AddInclude(x => x.MeetingType);
        }
    }
}
