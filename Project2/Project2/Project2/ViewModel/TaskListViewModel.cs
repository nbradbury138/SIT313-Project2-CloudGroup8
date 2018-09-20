using Project2.Model;
using Project2.Data;
using Project2.View;
using Project2.Services;
using Plugin.Connectivity;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace Project2.ViewModel
{
    public class TaskListViewModel : BaseTaskViewModel
    {

        public ICommand AddTaskComm { get; private set; }

        public TaskListViewModel(INavigation navigation)
        {
            nav = navigation;
            taskRepo = new TaskDataRepository();

            AddTaskComm = new Command(async () => await ShowAddTask());

            //get user from application
            if (CrossConnectivity.Current.IsConnected)
                DataServices.Synchronise();
            TaskDataList = taskRepo.GetAllTasksForUser(SettingServices.Username);
        }

        async Task ShowAddTask()
        {
            await nav.PushAsync(new CreateTask());
        }

        async void ShowTaskDetails(int taskId)
        {          
           await nav.PushAsync(new TaskScreen(taskId));
        }

        TaskData selectedTask;
        public TaskData SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (value != null)
                {
                    selectedTask = value;
                    NotifyPropertyChanged("SelectedTask");
                    ShowTaskDetails(value.Id);
                }
            }
        }
    }
}