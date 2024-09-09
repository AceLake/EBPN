using System;
using System.ComponentModel.DataAnnotations;
namespace EBPN_Network.Models;
public class Notification
{
    [Key]
    public int NotificationID { get; set; }

    [Required]
    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsRead { get; set; }

    public int UserID { get; set; }
    public User User { get; set; }
}
