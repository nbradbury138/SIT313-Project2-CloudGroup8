using Project2.Services;
using System.Windows.Input;
using Xamarin.Forms;
using Project2.View;

namespace Project2.ViewModel
{
    class LoginViewModel
    {
        UserServices userServices = new UserServices();

        public INavigation navigation;

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public LoginViewModel(INavigation nav)
        {
            navigation = nav;
        }

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

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await navigation.PushAsync(new Registration());
                });
            }
        }
    }
}

