using WebApiServis.Token;

namespace WebApiServis.Interfaces
{
    public interface IUserService
    {
        TokenResponse Authenticate(string user, string password);
        string RefreshToken(string token);
    }

}
