using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.EntityConfiguration;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Gender)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(x => x.Email)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(x => x.IsActive)
            .IsRequired();

    }
}