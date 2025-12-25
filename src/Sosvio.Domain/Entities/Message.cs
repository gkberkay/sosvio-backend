namespace Sosvio.Domain.Entities;

public class Message : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }

    // Foreign Keys
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public Guid ListingId { get; set; }

    // Navigation Properties
    public User Sender { get; set; } = null!;
    public User Receiver { get; set; } = null!;
    public Listing Listing { get; set; } = null!;
}