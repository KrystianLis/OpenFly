using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public int ProductTypeId { get; set; }

    }
}
