using Domain;
using Logic.Services;
using Presentation.Pages;
using System.Linq;
using System.Windows.Controls;

namespace Presentation.ViewModels
{
    public class AuthorizationViewModel : ViewModelBase
    {
        private string userName;
        private ApplicationService mainService;
        private string errorMessage;

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
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

        public RellayCommand LoginCommand { get; }
        public RellayCommand RegisterCommand { get; }

        public AuthorizationViewModel()
        {
            mainService = ServiceConfiguration.GetMainService();
            LoginCommand = new RellayCommand(EnterAction);
            RegisterCommand = new RellayCommand(RegisterAction);
        }

        private void RegisterAction(object obj)
        {
            App.RegisterPage = new Register();
            App.MainWindowViewModel.CurrentPage = App.RegisterPage;
        }

        private void EnterAction(object obj)
        {

            var passwordBox = obj as PasswordBox;
            if (string.IsNullOrEmpty(UserName))
            {
                ErrorMessage = "Enter UserName";
                return;
            }
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                ErrorMessage = "Enter password";
                return;
            }

            var password = passwordBox.Password;

            if (UserName == "admin" && password == "admin")
            {
                App.AdminPage = new Admin();
                App.MainWindowViewModel.CurrentPage = App.AdminPage;
            }

            var users = mainService.userRepository.Get();

            var user = users.FirstOrDefault(x => x.UserName == UserName);
            if (user != null)
            {
                var isAllowed = mainService.DecryptPassword(user.Password, password);

                if (!isAllowed)
                {
                    ErrorMessage = "Wrong UserName and/or Password";
                    return;
                }
                    
                CurrentUser.SetUserId(user.Id);
                App.MyResumesPage = new MyResumes();
                App.MainWindowViewModel.CurrentPage = App.MyResumesPage;
            }
            else
            {
                ErrorMessage = "Wrong UserName and/or Password";
            }
        }
    }
}
