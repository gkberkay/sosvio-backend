using Microsoft.EntityFrameworkCore;
using Sosvio.Application.Common.Interfaces;
using Sosvio.Domain.Entities;

namespace Sosvio.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<ListingImage> ListingImages => Set<ListingImage>();
    public DbSet<Message> Messages => Set<Message>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Burada gelecekte audit fields (CreatedAt, UpdatedAt) güncellenebilir
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}