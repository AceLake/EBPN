using EBPN_Network.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EBPN_Network.Models;
public class User
{
    [Key]
    public string UserID { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [StringLength(100)]
    public string Country { get; set; }

    [StringLength(50)]
    public string PreferredLanguage { get; set; }

    public ICollection<OutreachRequest> Requests { get; set; }
}
