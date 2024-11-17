using Microsoft.EntityFrameworkCore;
using Users.Application.Core.Abstractions;
using Users.Domain.Entities;

namespace Users.Infrastructure.Database;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Address> Addresses => Set<Address>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
