using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.IsPrivate).IsRequired();
            builder.Property(x => x.LocationId).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.MeetingType).WithMany()
                .HasForeignKey(x => x.MeetingTypeId);
            builder.HasOne(x => x.Location).WithMany()
                .HasForeignKey(x => x.LocationId);
        }
    }
}
