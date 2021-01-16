using Core.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Meeting : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User Organizer { get; set;}
        public string OrganizerId { get; set; }
        public bool IsPrivate { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public string PictureUrl { get; set; }
        public MeetingType MeetingType { get; set; }
        public int? MeetingTypeId { get; set; }
        public decimal? Price { get; set; }
        public IReadOnlyList<UserMeeting> UserMeeting { get; set; }
    }
}
