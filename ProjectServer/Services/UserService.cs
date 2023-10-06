using Microsoft.IdentityModel.Tokens;
using ProjectCommon.Models.Authentication;
using ProjectServer.Data;
using ProjectServer.Interfaces.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectServer.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? Login(LoginRequest request)
        {
            var user = _dbContext.Users
                .Where(x => x.Username == request.Username)
                .Where(x => x.Password == request.Password)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim("Id", user.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7143",
                audience: "https://localhost:7143",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(300),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")), SecurityAlgorithms.HmacSha256)
            );

            user.Jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return user;
        }

        public bool Register(RegisterRequest request)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                var hasUserExists = _dbContext.Users.Any(x => x.Username == request.Username);

                if (hasUserExists)
                {
                    return false;
                }

                var user = new User
                {
                    Username = request.Username,
                    Password = request.Password,
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                trans.Commit();
            }

            return true;
        }
    }
}
