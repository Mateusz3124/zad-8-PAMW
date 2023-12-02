using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06Shop.Shared.Auth;
using P06Shop.Shared.Services.AuthService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        public string Token { get; set; } = string.Empty;

        public LoginViewModel(IAuthService authService)
        {
            UserLoginDTO = new UserLoginDTO();
            _authService = authService;
        }

        [ObservableProperty]
        private UserLoginDTO userLoginDTO;

        [RelayCommand]
        public async void Login()
        {
            var response = await _authService.Login(UserLoginDTO);
            if (response.Success)
            {
                Token = response.Data;
            }
            else
            {

            }
            
        }
    }

}
