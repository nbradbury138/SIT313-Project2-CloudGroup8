using Project2.Services;
using Project2.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Project2.View;
using Plugin.Connectivity;

namespace Project2.ViewModel
{
    class LoginViewModel
    {
        UserServices userServices = new UserServices();

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation navigation;

        public string Email { get; set; }
        public string Password { get; set; }
        public string Message
        {
            get { return errorMessages; }
            set
            {
                errorMessages = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
            }
        }

        private string errorMessages { get; set; }
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
                        SettingServices.Username = Email;
                        SettingServices.Password = Password;
                        SettingServices.AccessToken = loggedIn.AccessToken;
                        SettingServices.AccessTokenExpirationDate = loggedIn.ExpirationTime;

                        // var accessToken = loggedIn.AccessToken;
                        // Application.Current.Properties["username"] = Email;
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

