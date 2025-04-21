using ContactSystem.Context.Map;
using ContactSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactSystem.Context;

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
