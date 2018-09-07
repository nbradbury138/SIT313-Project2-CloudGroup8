using System;

using Xamarin.Forms;

namespace Project2.View
{
    public class Registration : ContentPage
    {
        public Registration()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

