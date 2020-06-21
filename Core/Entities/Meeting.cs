using System;

namespace Core.Entities
{
    public class Meeting : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public string PictureUrl { get; set; }
        public MeetingType MeetingType { get; set; }
        public int MeetingTypeId { get; set; }
        public decimal Price { get; set; }
        public int? Count { get; set; }
    }
}
