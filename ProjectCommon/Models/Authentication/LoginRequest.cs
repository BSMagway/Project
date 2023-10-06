using ProjectCommon.ViewModelBase;

namespace ProjectCommon.Models.Authentication
{
    /// <summary>
    /// Запрос для логина пользователя.
    /// </summary>
    public class LoginRequest : ViewModel
    {
        private string username = string.Empty;
        private string password = string.Empty;

        /// <summary>
        /// Логин.
        /// </summary>
        public string Username
        {
            get => username;
            set => Set(ref username, value);
        }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password
        {
            get => password;
            set => Set(ref password, value);
        }
    }
}
