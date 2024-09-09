namespace EBPN_Network.Models
{
    public class ErrorViewModel
    {
        // Here
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}