using System.Threading.Tasks;
using System.Windows.Input;
using Project2.Model;
using Project2.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Project2.View;
using System;
using Xamarin.Forms;

namespace Project2.ViewModel
{
    public class TaskDetailViewModel : BaseTaskViewModel
    {
        //commands used for buttons/updating/deleting actions
        public ICommand UpdateTaskComm { get; private set; }
        public ICommand DeleteTaskComm { get; private set; }

        //constructor to take the navigation and the selected task
        public TaskDetailViewModel(INavigation navigation, int selectedTask)
        {
            //set the variables from the inherited class
            nav = navigation;
            task = new TaskData();
            task.Id = selectedTask;
            taskRepo = new TaskDataRepository();

            //set the commands
            UpdateTaskComm = new Command(async () => await UpdateTask());
            DeleteTaskComm = new Command(async () => await DeleteTask());

            //call the fetch task method
            FetchTask();
        }

        //set the task to the one retrieved from the data repo.
        void FetchTask()
        {
            task = taskRepo.GetTask(task.Id);
        }

        //ask if the user is sure they want to update and then update via the task repo
        async Task UpdateTask()
        {
            bool accept = await Application.Current.MainPage.DisplayAlert("Task Details", "Update Task", "OK", "Cancel");
            if (accept)
            {
                task.LastModifiedDate = DateTime.Now;
                taskRepo.UpdateTask(task);
                await nav.PopAsync();
            }
        }

        //ask if the user is sure they want to delete and then delete via the task repo
        async Task DeleteTask()
        {
            bool accept = await Application.Current.MainPage.DisplayAlert("Task Details", "Delete Task", "OK", "Cancel");
            if (accept)
            {
                taskRepo.DeleteTask(task.Id);
                await nav.PushAsync(new HomePage());
            }
        }
    }
}