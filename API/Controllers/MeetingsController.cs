using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MeetingsController : BaseApiController
    {
        private readonly IGenericRepository<Meeting> _meetingRepo;
        private readonly IGenericRepository<MeetingType> _meetingTypeRepo;
        private readonly IMapper _mapper;

        public MeetingsController(IGenericRepository<Meeting> meetingRepo, IGenericRepository<MeetingType> meetingTypeRepo, IMapper mapper)
        {
            _meetingRepo = meetingRepo;
            _meetingTypeRepo = meetingTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MeetingDto>>> GetMeetings()
        {
            var spec = new MeetingsWithTypesSpecification();

            var meetings = await _meetingRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Meeting>, IReadOnlyList<MeetingDto>>(meetings));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDto>> GetMeeting(int id)
        {
            var spec = new MeetingsWithTypesSpecification(id);
            var meeting = await _meetingRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Meeting, MeetingDto>(meeting);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<MeetingType>>> GetMeetingTypes()
        {
            return Ok(await _meetingTypeRepo.ListAsync());
        }
    }
}
