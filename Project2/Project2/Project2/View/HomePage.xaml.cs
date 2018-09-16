using System;
using System.Collections.Generic;
using Project2.ViewModel;
using Xamarin.Forms;

namespace Project2.View
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new TaskListViewModel(Navigation);
        }

        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            TaskListViewModel vm = (TaskListViewModel)BindingContext;
            vm.TaskDataList.Clear();
            vm.TaskDataList = vm.taskRepo.GetAllTasks();
        }
        */
    }
}
