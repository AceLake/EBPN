using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;
namespace EBPN_Network.Models;

[FirestoreData]
public class User
{
    [FirestoreProperty]
    public string Id { get; set; }  // Unique identifier for the user (e.g., UUID or Firestore document ID)

    public string Uid { get; set; }

    [FirestoreProperty]
    [Required]
    public string Email { get; set; }  // Email address of the user

    [FirestoreProperty]
    public string FirstName { get; set; }  // Optional: User's first name

    [FirestoreProperty]
    public string LastName { get; set; }  // Optional: User's last name

    [FirestoreProperty]
    public string PhoneNumber { get; set; }  // Optional: User's phone number

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; }  // Optional: Timestamp of when the user was created

    [FirestoreProperty]
    public DateTime? UpdatedAt { get; set; }  // Optional: Timestamp of the last update
}
