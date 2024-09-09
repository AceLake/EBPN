using System;
using System.ComponentModel.DataAnnotations;
namespace EBPN_Network.Models;
public class BibleDistribution
{
    [Key]
    public int DistributionID { get; set; }

    [Required]
    [StringLength(100)]
    public string Language { get; set; }

    [Required]
    [StringLength(100)]
    public string Country { get; set; }

    [Required]
    public string OrganizationName { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
