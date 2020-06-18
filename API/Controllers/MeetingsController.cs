using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : Controller
    {
        private readonly MeetingContext _context;

        public MeetingsController(MeetingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Meeting>>> GetMeetings()
        {
            var meetings = await _context.Meetings.ToListAsync();

            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeeting(int id)
        {
            return await _context.Meetings.FindAsync(id);
        }
    }
}
