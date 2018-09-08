using Project2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project2.ViewModel
{
    public class RegisterViewModel
    {
        UserServices userServices = new UserServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var loggedIn = await userServices.RegisterUserAsync(Email, Password, ConfirmPassword);

                    if (loggedIn)
                        Message = "Registration Successful";
                    else
                        Message = "Registration Failed";
                });
            }
        }
    }
}