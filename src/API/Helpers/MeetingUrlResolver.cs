using API.DTO;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class MeetingUrlResolver : IValueResolver<Meeting, MeetingDTO, string>
    {
        private readonly IConfiguration _config;

        public MeetingUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Meeting source, MeetingDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
