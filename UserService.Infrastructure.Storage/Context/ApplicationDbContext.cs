using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<OrganizationModel> Organizations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganizationModel>().HasMany(x => x.Users).WithOne(x => x.Organization)
            .HasForeignKey(u => u.OrganizationId).OnDelete(DeleteBehavior.Cascade);
    }
}