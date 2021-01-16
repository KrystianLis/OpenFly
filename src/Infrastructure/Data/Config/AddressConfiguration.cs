using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.City)
                .HasMaxLength(30);
            builder.Property(x => x.Street)
                .HasMaxLength(75);
            builder.Property(x => x.City)
                .HasMaxLength(30);
            builder.Property(x => x.ZipCode)
                .HasMaxLength(10);
        }
    }
}
