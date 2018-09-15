using System;
using System.Collections.Generic;
using Project2.ViewModel;
using Xamarin.Forms;

namespace Project2.View
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }
}
