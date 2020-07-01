using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Meeting, MeetingDto>()
                .ForMember(d => d.MeetingType, o => o.MapFrom(s => s.MeetingType.Name));
        }
    }
}
