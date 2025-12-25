namespace Sosvio.Domain.Entities;

public class ListingImage : BaseEntity
{
    public string ImageUrl { get; set; } = string.Empty;
    public string? ThumbnailUrl { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPrimary { get; set; }

    // Foreign Key
    public Guid ListingId { get; set; }

    // Navigation Property
    public Listing Listing { get; set; } = null!;
}