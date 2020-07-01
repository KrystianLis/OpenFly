﻿using System;

namespace API.DTO
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public string PictureUrl { get; set; }
        public string MeetingType { get; set; }
        public decimal Price { get; set; }
        public int? Count { get; set; }
    }
}
