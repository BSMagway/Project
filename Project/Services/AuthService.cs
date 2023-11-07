using Project.Interfaces.Services;
using ProjectCommon.Models.Authentication;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Project.Services
{
    /// <summary>
    /// Сервис для авторизации пользователя.
    /// </summary>
    internal class AuthService : IAuthInterface
    {
        static HttpClient httpClient = new HttpClient();

        static JsonSerializerOptions optionsCyr = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };


        public async Task<User> Login(string address, LoginRequest loginRequest)
        {
            JsonContent content = JsonContent.Create(loginRequest, null, optionsCyr);

            using var response = await httpClient.PostAsync(address, content);

            User item = new User();

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Ошибка входа.");
            }
            else
            {
                item = await response.Content.ReadFromJsonAsync<User>();
            }

            return item;
        }

        public async Task Registration(string address, RegisterRequest registerRequest)
        {
            JsonContent content = JsonContent.Create(registerRequest, null, optionsCyr);

            using var response = await httpClient.PostAsync(address, content);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Ошибка входа.");
            }
            else
            {
                
            }
        }
    }
}
