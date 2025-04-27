using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infra.Context.Map;

namespace Infra.Context;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) { }

    public DbSet<ContactModel> Contacts { get; set; }
    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContactMap());

        base.OnModelCreating(modelBuilder);
    }
}
