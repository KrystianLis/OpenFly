using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly MeetingContext _context;

        public MeetingRepository(MeetingContext context)
        {
            _context = context;
        }

        public async Task<Meeting> GetMeetingByIdAsync(int id)
        {
            return await _context.Meetings.FindAsync(id);
        }

        public async Task<IReadOnlyList<Meeting>> GetMeetingsAsync()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task<IReadOnlyList<MeetingType>> GetMeetingTypesAsync()
        {
            return await _context.MeetingTypes.ToListAsync();
        }
    }
}
