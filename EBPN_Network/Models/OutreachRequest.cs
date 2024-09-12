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

    public OutreachRequest() { }
    public OutreachRequest(string requestID, string title, string description, string language, string country, string status, DateTime createdDate,string userID)
    {
        RequestID = requestID;
        Title = title;
        Description = description;
        Language = language;
        Country = country;
        Status = status;
        CreatedDate = createdDate;
        UserID = userID;
    }
}
