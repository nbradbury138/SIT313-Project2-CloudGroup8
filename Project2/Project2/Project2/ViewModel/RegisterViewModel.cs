using Project2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Project2.View;

namespace Project2.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        UserServices userServices = new UserServices();
        public INavigation navigation;

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public RegisterViewModel(INavigation nav)
        {
            navigation = nav;
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var registerUser = await userServices.RegisterUserAsync(Email, Password, ConfirmPassword);

                    if (registerUser.SuccessStatus)
                    {
                        Message = "Registration Successful";
                        var loggedIn = await userServices.LoginAsync(Email, Password);

                        if (loggedIn.SuccessStatus)
                        {
                            var accessToken = loggedIn.AccessToken;
                            await navigation.PushAsync(new HomePage());
                        }
                        else
                        {
                            Message = loggedIn.ErrorMessage;
                        }
                    }
                    else
                        Message = "Registration Failed";
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}