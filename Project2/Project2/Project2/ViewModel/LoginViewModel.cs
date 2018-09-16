using Project2.Services;
using Project2.View;
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
        public INavigation Navigation { get; set; }

        public LoginViewModel()
        {
        }

        public LoginViewModel(INavigation nav)
        {
            Navigation = nav;
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
                        if (Navigation != null)
                            await Navigation.PushAsync(new HomePage());
                        else
                            new HomePage();
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

