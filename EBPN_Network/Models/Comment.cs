using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel.DataAnnotations;
namespace EBPN_Network.Models;
public class Comment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CommentID { get; set; }

    [Required]
    public string Text { get; set; }

    public DateTime CreatedDate { get; set; }

    public string UserID { get; set; }
    public User User { get; set; }

    public string RequestID { get; set; }
    public OutreachRequest OutreachRequest { get; set; }

    public Comment()
    {

    }
}
