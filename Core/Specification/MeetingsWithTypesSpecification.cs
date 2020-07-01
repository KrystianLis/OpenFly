using Core.Entities;
using System;
using System.Linq.Expressions;

namespace Core.Specification
{
    public class MeetingsWithTypesSpecification : BaseSpecification<Meeting>
    {
        public MeetingsWithTypesSpecification()
        {
            AddInclude(x => x.MeetingType);
        }

        public MeetingsWithTypesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.MeetingType);
        }
    }
}
