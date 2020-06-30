﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await _context.Meetings
                                .Include(x => x.MeetingType)
                                .FirstOrDefaultAsync(x => x. Id == id);
        }

        public async Task<IReadOnlyList<Meeting>> GetMeetingsAsync()
        {
            return await _context.Meetings
                .Include(x => x.MeetingType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<MeetingType>> GetMeetingTypesAsync()
        {
            return await _context.MeetingTypes.ToListAsync();
        }
    }
}
