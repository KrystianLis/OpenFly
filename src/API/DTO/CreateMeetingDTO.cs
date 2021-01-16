using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class CreateMeetingDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsPrivate { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string PictureUrl { get; set; }
        [Required]
        public int? MeetingTypeId { get; set; }
        public decimal? Price { get; set; }
    }
}
