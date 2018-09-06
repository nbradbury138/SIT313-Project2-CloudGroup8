using System.Threading.Tasks;
using System.Windows.Input;
using Project2.Model;
using Project2.Data;
using Project2.View;


using Xamarin.Forms;

namespace Project2.ViewModel
{
    public class AddUserViewModel : BaseUserViewModel
    {

        public ICommand AddUserComm { get; private set; }

        public AddUserViewModel(INavigation navigation)
        {
            nav = navigation;
            user = new UserData();
            userRepo = new UserDataRepository();

            AddUserComm = new Command(async () => await AddUser());
        }

        async Task AddUser()
        {
            bool accept = await Application.Current.MainPage.DisplayAlert("Add User", "Save User Details?", "OK", "Cancel");
            if (accept)
            {
                userRepo.InsertUser(user);
                await nav.PushAsync(new Page1());
            }
        }
    }
}