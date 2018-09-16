using Project2.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project2.ViewModel
{
    class LoginViewModel
    {
        UserServices userServices = new UserServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var loggedIn = await userServices.LoginAsync(Email, Password);

                    if (loggedIn.SuccessStatus)
                    {
                        var accessToken = loggedIn.AccessToken;
                        Application.Current.Properties["username"] = Email;
                        await navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        Message = loggedIn.ErrorMessage;
                    }
                });
            }
        }
    }
}

