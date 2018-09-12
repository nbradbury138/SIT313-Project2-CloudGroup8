using System;
using System.Collections.Generic;
using Project2.ViewModel;

using Xamarin.Forms;

namespace Project2.View
{
    public partial class TaskScreen : ContentPage
    {
        public TaskScreen ()
        {
            InitializeComponent();
        }

        public TaskScreen(int id)
        {
            InitializeComponent();

            BindingContext = new TaskDetailViewModel(Navigation,id);
        }
    }
}
