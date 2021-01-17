using Core.Entities;

namespace Core.Specification
{
    public class MeetingsWithTypesSpecification : BaseSpecification<Meeting>
    {
        public MeetingsWithTypesSpecification(MeetingSpecParams meetingParams)
            : base(x => 
                (string.IsNullOrEmpty(meetingParams.Search) || x.Name.ToLower().Contains(meetingParams.Search)) &&
                (!meetingParams.TypeId.HasValue || x.MeetingTypeId == meetingParams.TypeId))
        {
            AddInclude(x => x.MeetingType);
            AddInclude(x => x.Location);
            AddInclude(x => x.Organizer);

            AddOrderBy(x => x.Name);
            ApplyPaging(meetingParams.PageSize * (meetingParams.PageIndex - 1), meetingParams.PageSize);

            if (!string.IsNullOrEmpty(meetingParams.Sort))
            {
                switch (meetingParams.Sort)
                {
                    case "dateAsc":
                        AddOrderBy(p => p.Date);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(p => p.Date);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public MeetingsWithTypesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.MeetingType);
            AddInclude(x => x.Location);
            AddInclude(x => x.Organizer);
        }
    }
}
