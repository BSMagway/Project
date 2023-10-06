namespace ProjectCommon.Models.Authentication
{
    /// <summary>
    /// Запрос для регистрации пользователя.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }

    }
}
