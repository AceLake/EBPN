using System;
using System.ComponentModel.DataAnnotations;
namespace EBPN_Network.Models;
public class FileAttachment
{
    [Key]
    public int AttachmentID { get; set; }

    [Required]
    public string FilePath { get; set; }

    [Required]
    public string FileType { get; set; } // e.g., "image", "document"

    public DateTime UploadedDate { get; set; }

    public int RequestID { get; set; }
    public OutreachRequest OutreachRequest { get; set; }
}
