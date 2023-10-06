using ProjectCommon.Models.Authentication;

namespace ProjectServer.Interfaces.Service
{
    public interface IUserService
    {
        LoginResult? Login(LoginRequest request);

        bool Register(RegisterRequest request);
    }
}
