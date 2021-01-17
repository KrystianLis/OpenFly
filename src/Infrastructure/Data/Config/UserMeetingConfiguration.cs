using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class UserMeetingConfiguration : IEntityTypeConfiguration<UserMeeting>
    {
        public void Configure(EntityTypeBuilder<UserMeeting> builder)
        {
            builder.Ignore(c => c.Id);
            builder.HasKey(x => new { x.UserId, x.MeetingId });
            builder.HasOne(x => x.Meeting)
                .WithMany(x => x.UserMeeting)
                .HasForeignKey(x => x.MeetingId);
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserMeeting)
                .HasForeignKey(x => x.UserId);
        }
    }
}
