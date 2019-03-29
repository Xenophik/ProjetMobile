using Client.Helpers;
using Client.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Client.ViewModels
{
    public class RegisterViewModel
    {
        private readonly APIServices _apiServices = new APIServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isRegistered = await _apiServices.RegisterUserAsync
                        (Username, Password, ConfirmPassword);

                    Settings.Username = Username;
                    Settings.Password = Password;

                    if (isRegistered)
                    {
                        Message = "Success :)";
                    }
                    else
                    {
                        Message = "Please try again :(";
                    }
                });
            }
        }
    }
}
