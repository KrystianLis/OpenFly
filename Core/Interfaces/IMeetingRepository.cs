using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMeetingRepository
    {
        Task<Meeting> GetMeetingByIdAsync(int id);
        Task<IReadOnlyList<Meeting>> GetMeetingsAsync();
    }
}
