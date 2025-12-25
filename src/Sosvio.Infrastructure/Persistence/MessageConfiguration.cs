using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sosvio.Domain.Entities;

namespace Sosvio.Infrastructure.Persistence.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("messages");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Content)
            .IsRequired()
            .HasMaxLength(2000);

        builder.HasIndex(m => m.CreatedAt);
        builder.HasIndex(m => new { m.SenderId, m.ReceiverId });
        builder.HasIndex(m => m.ListingId);

        builder.HasQueryFilter(m => !m.IsDeleted);
    }
}