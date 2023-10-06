using ProjectCommon.Models.Authentication;
using System.Threading.Tasks;

namespace Project.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для работы с пользователями.
    /// </summary>
    internal interface IAuthInterface
    {
        /// <summary>
        /// Метод для авторизации пользователя.
        /// </summary>
        /// <param name="address">Адрес для отправки запроса на авторизацию.</param>
        /// <param name="loginRequest">Данные запроса на авторизацию.</param>
        /// <returns>Авторизированный пользователь.</returns>
        public Task<User> Login(string address, LoginRequest loginRequest);

        /// <summary>
        /// Метод для регистрации пользователей.
        /// </summary>
        /// <param name="address">Адрес для отправки запроса на регистрацию.</param>
        /// <param name="user">Данные нового пользователя для регистрации.</param>
        /// <returns></returns>
        public Task Registration(string address, User user);
    }
}
