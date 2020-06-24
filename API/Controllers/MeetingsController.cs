using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : Controller
    {
        private readonly IMeetingRepository _repo;

        public MeetingsController(IMeetingRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Meeting>>> GetMeetings()
        {
            var meetings = await _repo.GetMeetingsAsync();

            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeeting(int id)
        {
            return await _repo.GetMeetingByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<MeetingType>>> GetMeetingTypes()
        {
            return Ok(await _repo.GetMeetingTypesAsync());
        }
    }
}
