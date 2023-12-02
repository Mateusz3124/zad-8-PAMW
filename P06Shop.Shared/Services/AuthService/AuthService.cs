using P06Shop.Shared.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using P06.Shared;
using Newtonsoft.Json;
using P06.Shared.Books;

namespace P06Shop.Shared.Services.AuthService
{
    public class AuthService : IAuthService
    {
    
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login/", userLoginDto);

            var data =  await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            return data;
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterDTO userRegisterDTO)
        {
            JsonContent content = JsonContent.Create(userRegisterDTO);
            var result = await _httpClient.PostAsync("api/auth/register", content);
            var data = await result.Content.ReadAsStringAsync();
            var resulter = JsonConvert.DeserializeObject<ServiceResponse<int>>(data);
            return resulter;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(string newPassword)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/change-password/", newPassword);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
