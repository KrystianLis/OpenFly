using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMeetingRepository
    {
        Task<Meeting> GetMeetingByIdAsync(int id);
        Task<IReadOnlyList<Meeting>> GetMeetingsAsync();
    }
}
