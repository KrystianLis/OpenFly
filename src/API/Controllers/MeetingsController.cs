using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MeetingsController : BaseApiController
    {
        private readonly IGenericRepository<Meeting> _meetingRepo;
        private readonly IGenericRepository<MeetingType> _meetingTypeRepo;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeetingsController(IGenericRepository<Meeting> meetingRepo, IGenericRepository<MeetingType> meetingTypeRepo, UserManager<User> userManager,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _meetingRepo = meetingRepo;
            _meetingTypeRepo = meetingTypeRepo;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<MeetingDTO>>> GetMeetings([FromQuery] MeetingSpecParams meetingParams)
        {
            var spec = new MeetingsWithTypesSpecification(meetingParams);

            var countSpec = new MeetingWithFilterCountSpecification(meetingParams);

            var totalItems = await _meetingRepo.CountAsync(countSpec);

            var meetings = await _meetingRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Meeting>, IReadOnlyList<MeetingDTO>>(meetings);

            return Ok(new Pagination<MeetingDTO>(meetingParams.PageIndex, meetingParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MeetingDTO>> GetMeeting(int id)
        {
            var spec = new MeetingsWithTypesSpecification(id);
            var meeting = await _meetingRepo.GetEntityWithSpec(spec);

            if (meeting is null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<Meeting, MeetingDTO>(meeting);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<MeetingType>>> GetMeetingTypes()
        {
            return Ok(await _meetingTypeRepo.ListAsync());
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CreateMeetingDTO>> CreateMeeting(CreateMeetingDTO meetingDto)
        {
            var meeting = _mapper.Map<CreateMeetingDTO, Meeting>(meetingDto);

            var user = await _userManager.FindByEmailAsync(HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value);
            meeting.OrganizerId = user.Id;

            meeting.UserMeeting = new List<UserMeeting>
            {
                new UserMeeting
                {
                    User = user,
                    Meeting = meeting
                }
            };

            _unitOfWork.Repository<Meeting>().Create(meeting);
            await _unitOfWork.Complete();

            return Ok(meetingDto);
        }
    }
}
