using System.ComponentModel.DataAnnotations;
namespace EBPN_Network.Models;
public class Category
{
    [Key]
    public int CategoryID { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public string Description { get; set; }
}
