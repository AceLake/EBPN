using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EBPN_Network.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  // Unique identifier (MongoDB ObjectId)

        [BsonElement("email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }  // User's email address

        [BsonElement("passwordHash")]
        [Required]
        public string PasswordHash { get; set; }  // Hashed password for security

        [BsonElement("firstName")]
        public string FirstName { get; set; }  // Optional: User's first name

        [BsonElement("lastName")]
        public string LastName { get; set; }  // Optional: User's last name

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }  // Optional: User's phone number

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Date when the user was created

        [BsonElement("updatedAt")]
        public DateTime? UpdatedAt { get; set; }  // Optional: Date when the user was last updated

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
