using Microsoft.EntityFrameworkCore;

namespace ProjectCommon.Models.Authentication
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

    }
}
