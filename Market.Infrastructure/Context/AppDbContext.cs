using Market.Domain.Entities;
using Market.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new MemberConfiguration());
    }
}