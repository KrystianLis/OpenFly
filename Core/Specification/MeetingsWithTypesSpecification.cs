using Core.Entities;

namespace Core.Specification
{
    public class MeetingsWithTypesSpecification : BaseSpecification<Meeting>
    {
        public MeetingsWithTypesSpecification(string sort)
        {
            AddInclude(x => x.MeetingType);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
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
        }
    }
}
