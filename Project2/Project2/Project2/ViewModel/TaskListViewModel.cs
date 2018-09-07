using System.Threading.Tasks;
using System.Windows.Input;
using Project2.Model;
using Project2.Data;


using Xamarin.Forms;

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

            FetchTasks();
        }

        void FetchTasks()
        {
            TaskDataList = taskRepo.GetAllTasks();
        }

        async Task ShowAddTask()
        {
            //await nav.PushAsync(new Add());
        }

        async void ShowTaskDetails(int taskId)
        {
           // await nav.PushAsync(new Details(taskId));
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