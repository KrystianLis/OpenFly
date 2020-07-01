using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : Controller
    {
        private readonly IGenericRepository<Meeting> _meetingRepo;
        private readonly IGenericRepository<MeetingType> _meetingTypeRepo;

        public MeetingsController(IGenericRepository<Meeting> meetingRepo, IGenericRepository<MeetingType> meetingTypeRepo)
        {
            _meetingRepo = meetingRepo;
            _meetingTypeRepo = meetingTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<MeetingDto>>> GetMeetings()
        {
            var spec = new MeetingsWithTypesSpecification();

            var meetings = await _meetingRepo.ListAsync(spec);

            return meetings.Select(meeting => new MeetingDto
            {
                Id = meeting.Id,
                Name = meeting.Name,
                Description = meeting.Description,
                PictureUrl = meeting.PictureUrl,
                Place = meeting.Place,
                Date = meeting.Date,
                MeetingType = meeting.MeetingType.Name,
                Count = meeting.Count,
                Price = meeting.Price,
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDto>> GetMeeting(int id)
        {
            var spec = new MeetingsWithTypesSpecification(id);
            var meeting = await _meetingRepo.GetEntityWithSpec(spec);

            return new MeetingDto
            {
                Id = meeting.Id,
                Name = meeting.Name,
                Description = meeting.Description,
                PictureUrl = meeting.PictureUrl,
                Place = meeting.Place,
                Date = meeting.Date,
                MeetingType = meeting.MeetingType.Name,
                Count = meeting.Count,
                Price = meeting.Price,
            };
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<MeetingType>>> GetMeetingTypes()
        {
            return Ok(await _meetingTypeRepo.ListAsync());
        }
    }
}
