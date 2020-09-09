using Domain;
using Domain.Models;
using Logic.Services;
using Presentation.Pages;
using System.Linq;
using System.Text.RegularExpressions;

namespace Presentation.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private ApplicationService mainService;
        private string userName;
        private string errorMessage;
        private string mail;

        public RegistrationViewModel()
        {
            mainService = ServiceConfiguration.GetMainService();
            ToAuthorizationCommand = new RellayCommand(ToAuthorization);
            RegisterCommand = new RellayCommand(RegisterAction);
        }

        public RellayCommand RegisterCommand { get; }
        public RellayCommand ToAuthorizationCommand { get; }
        public string Password { private get; set; }
        public string ConfirmPassword { private get; set; }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string Mail
        {
            get => mail;
            set
            {
                mail = value;
                OnPropertyChanged(nameof(Mail));
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        private void ToAuthorization(object obj)
        {
            App.LoginPage = new Login();
            App.MainWindowViewModel.CurrentPage = App.LoginPage;
        }

        private async void RegisterAction(object obj)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                ErrorMessage = "Enter UserName";
                return;
            }
            if(UserName.Length<6)
            {
                ErrorMessage = "Short UserName";
                return;
            }
            if (string.IsNullOrEmpty(Mail))
            {
                ErrorMessage = "Enter Email";
                return;
            }
            Match isMatch = Regex.Match(mail, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", RegexOptions.IgnoreCase);
            if (isMatch.Success == false)
            {
                ErrorMessage = "Incorrect Email";
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Enter Password";
                return;
            }
            if(Password.Length<6)
            {
                ErrorMessage = "Short Password";
                return;
            }
            if(mainService.userRepository.Get().FirstOrDefault(X=>X.Mail==Mail||X.UserName==UserName)!=null)
            {
                ErrorMessage = "This user has already existed";
                return;
            }

            if (Password == ConfirmPassword)
            {
                var users = mainService.userRepository.Get();
                var message = await mainService.AddUserAsync(new User() { UserName = UserName, Password = Password, City = "", FirstName = "", SecondName = "", Mail = Mail, });

                if (message == null)
                {
                    CurrentUser.SetUserId(users.FirstOrDefault(x => x.UserName == UserName).Id);
                    App.MyResumesPage = new MyResumes();
                    App.MainWindowViewModel.CurrentPage = App.MyResumesPage;
                    return;
                }
                else
                {
                    ErrorMessage = message;
                    return;
                }
            }
            else
            {
                ErrorMessage = "Passwords don't match";
                return;
            }
        }
    }
}