﻿using EBPN_Network.Models;
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
    public string Category { get; set; }

    [Required]
    public string Description { get; set; }

    [StringLength(50)]
    public string PostLanguage { get; set; }

    [StringLength(50)]
    public string ResponseLanguage { get; set; }


    [StringLength(100)]
    public string Country { get; set; }

    [Required]
    public bool Fulfilled { get; set; } // e.g., "Open", "Fulfilled", "In Progress"

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string UserID { get; set; }

    public string Email { get; set; }

    public string WhatsApp { get; set; }

    public bool Flagged { get; set; }

    public bool Disclaimer { get; set; }

}