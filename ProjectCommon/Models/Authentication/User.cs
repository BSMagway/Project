using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCommon.Models.Authentication
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        /// <summary>
        /// Id в базе данных.
        /// </summary>
        public int Id { get; set; }

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
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Jwt токен.
        /// </summary>
        [NotMapped]
        public string Jwt { get; set; }

    }
}
