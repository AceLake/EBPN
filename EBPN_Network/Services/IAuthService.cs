using EBPN_Network.Models;

namespace EBPN_Network.Services
{
    public interface IAuthService
    {
        bool ValidatePassword(User user, string password);
        string GenerateJwtToken(User user);
    }
}
