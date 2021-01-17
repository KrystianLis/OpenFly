using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Meeting, MeetingDTO>()
                .ForMember(d => d.MeetingType, o => o.MapFrom(s => s.MeetingType.Name))
                .ForMember(d => d.OrganizerUserName, o => o.MapFrom(s => s.Organizer.UserName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<MeetingUrlResolver>());

            CreateMap<Meeting, CreateMeetingDTO>()
                .ReverseMap();

            CreateMap<Address, AddressDTO>()
                .ReverseMap();
        }
    }
}
