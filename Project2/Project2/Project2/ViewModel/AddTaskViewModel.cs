using System.Threading.Tasks;
using System.Windows.Input;
using Project2.Model;
using Project2.Data;
using Project2.View;
using System;
using Xamarin.Forms;
using Project2.Services;

namespace Project2.ViewModel
{
    public class AddTaskViewModel : BaseTaskViewModel
    {

        public ICommand AddTaskComm { get; private set; }

        public AddTaskViewModel(INavigation navigation)
        {
            nav = navigation;
            task = new TaskData();
            taskRepo = new TaskDataRepository();

            AddTaskComm = new Command(async () => await AddTask());
        }

        async Task AddTask()
        {
            bool accept = await Application.Current.MainPage.DisplayAlert("Add Task", "Save task details?", "OK", "Cancel");
            if (accept)
            {
                task.User = SettingServices.Username;
                task.LastModifiedDate = DateTime.Now;
                taskRepo.InsertTask(task);
                await nav.PushAsync(new HomePage());
            }
        }
    }
}