using Project2.Services; using Project2.View; using System; using System.Collections.Generic; using System.ComponentModel.DataAnnotations; using System.Text; using System.Threading.Tasks; using System.Windows.Input; using Xamarin.Forms;  namespace Project2.ViewModel {     public class LoginViewModel     {         UserServices userServices = new UserServices(); 		public ICommand RegPage { get; set; }         public INavigation navigation;         public string Email { get; set; }         public string Password { get; set; }         public string accessToken { get; set; }         public string Message { get; set; }          public ICommand LoginCommand         {             get             {                 return new Command(async () =>               {                   //var loggedIn = await userServices.LoginAsync(Email, Password);

                  bool loggedIn = true;
                  if (loggedIn)
                  {
                      Message = "Welcome Back !";
                      Application.Current.Properties["username"] = Email;
                      await navigation.PushAsync(new HomePage());
                  }
                  else
                  {
                      Message = "Invalid credentials, please try again.";
                  }                 });             }         }          public LoginViewModel(INavigation Navigation)         {             navigation = Navigation;                         RegPage = new Command(async () => await RegisterPage());         }          async Task RegisterPage()         {             await navigation.PushAsync(new Registration());         }              } }  