using Sosvio.Domain.Enums;

namespace Sosvio.Domain.Entities;

public class Listing : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public bool IsFree { get; set; }
    public string Location { get; set; } = string.Empty;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public ListingStatus Status { get; set; } = ListingStatus.Draft;
    public DateTime? PublishedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public int ViewCount { get; set; }
    public int ContactCount { get; set; }

    // Foreign Keys
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }

    // Navigation Properties
    public User User { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public ICollection<ListingImage> Images { get; set; } = new List<ListingImage>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}