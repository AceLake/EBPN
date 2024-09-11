using EBPN_Network.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel.DataAnnotations;
namespace EBPN_Network.Models;
public class OutreachRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string RequestID { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [StringLength(50)]
    public string Language { get; set; }

    [StringLength(100)]
    public string Country { get; set; }

    [Required]
    public string Status { get; set; } // e.g., "Open", "Fulfilled", "In Progress"

    public DateTime CreatedDate { get; set; }

    public string UserID { get; set; }

    public User User { get; set; } // Foreign key relationship

    public ICollection<Comment> Comments { get; set; }
    public ICollection<FileAttachment> FileAttachments { get; set; }
}
