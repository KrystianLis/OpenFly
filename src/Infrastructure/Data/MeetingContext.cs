using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Data
{
    public class MeetingContext : DbContext
    {
        public MeetingContext(DbContextOptions<MeetingContext> options) : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserMeeting> UserMeetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<UserMeeting>()
                .HasKey(x => new { x.UserId, x.MeetingId });
            modelBuilder.Entity<UserMeeting>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.UserMeeting)
                .HasForeignKey(x => x.MeetingId);
            modelBuilder.Entity<UserMeeting>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserMeeting)
                .HasForeignKey(x => x.UserId);

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}
