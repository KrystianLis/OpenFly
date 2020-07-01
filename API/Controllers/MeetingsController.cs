using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<List<Meeting>>> GetMeetings()
        {
            var spec = new MeetingsWithTypesSpecification();

            var meetings = await _meetingRepo.ListAsync(spec);

            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeeting(int id)
        {
            return await _meetingRepo.GetByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<MeetingType>>> GetMeetingTypes()
        {
            return Ok(await _meetingTypeRepo.ListAsync());
        }
    }
}
