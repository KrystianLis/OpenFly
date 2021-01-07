using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.DTO
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set;}
        public bool IsPrivate { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        public string PictureUrl { get; set; }
        public string MeetingType { get; set; }
        public decimal? Price { get; set; }
        public IReadOnlyList<UserMeeting> UserMeeting { get; set; }
    }
}
