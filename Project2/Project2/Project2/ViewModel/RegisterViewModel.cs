using Project2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project2.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        UserServices userServices = new UserServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Message
        {
            get { return errorMessages; }
            set
            {
                errorMessages = value;
                NotifyPropertyChanged("Message");
            }
        }

        private string errorMessages { get; set; }

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
                        }
                        else
                        {
                            Message = loggedIn.ErrorMessage;
                        }
                    }
                    else
                        Message = "Registration Failed - Please Check Username (must be unique) and Password (Must contain a Capital and Symbol)";
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region INotifyPropertyChanged      

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}