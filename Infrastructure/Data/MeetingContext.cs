using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MeetingContext : DbContext
    {
        public MeetingContext(DbContextOptions<MeetingContext> options) : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
    }
}
