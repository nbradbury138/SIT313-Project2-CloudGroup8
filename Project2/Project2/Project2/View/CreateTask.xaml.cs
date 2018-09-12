using System;
using System.Collections.Generic;
using Project2.ViewModel;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class CreateTask : ContentPage
    {
        public CreateTask()
        {
            InitializeComponent();
            BindingContext = new AddTaskViewModel(Navigation);
        }
    }
}
