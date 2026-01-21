using WinellyApi.Models;

namespace WinellyApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
