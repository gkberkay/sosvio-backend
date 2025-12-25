using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sosvio.Domain.Entities;
using Sosvio.Domain.Enums;

namespace Sosvio.Infrastructure.Persistence.Configurations;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.ToTable("listings");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(l => l.Description)
            .IsRequired()
            .HasMaxLength(5000);

        builder.Property(l => l.Price)
            .HasPrecision(18, 2);

        builder.Property(l => l.Location)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(l => l.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.HasIndex(l => l.Status);
        builder.HasIndex(l => l.PublishedAt);
        builder.HasIndex(l => new { l.CategoryId, l.Status });

        builder.HasQueryFilter(l => !l.IsDeleted);

        // Relationships configured in User and Category
        builder.HasMany(l => l.Images)
            .WithOne(i => i.Listing)
            .HasForeignKey(i => i.ListingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(l => l.Messages)
            .WithOne(m => m.Listing)
            .HasForeignKey(m => m.ListingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}