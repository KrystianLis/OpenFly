using Core.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
                .HasMaxLength(25);
            builder.Property(x => x.LastName)
                .HasMaxLength(25);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey<Address>(x => x.UserId);
        }
    }
}
