using Client.Helpers;
using Client.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Client.ViewModels
{
    class LoginViewModel
    {
        private readonly APIServices _apiServices = new APIServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);

                    Settings.AccessToken = accesstoken;
                });
            }
        }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
