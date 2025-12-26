using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sosvio.Domain.Entities;

namespace Sosvio.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Category> Categories { get; }
    DbSet<Listing> Listings { get; }
    DbSet<ListingImage> ListingImages { get; }
    DbSet<Message> Messages { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}