using ProjectCommon.Models.Authentication;

namespace ProjectServer.Interfaces.Service
{
    public interface IUserService
    {
        User? Login(LoginRequest request);

        bool Register(RegisterRequest request);
    }
}
