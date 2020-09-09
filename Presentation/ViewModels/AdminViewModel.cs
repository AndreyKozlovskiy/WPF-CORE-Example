using Domain;
using Domain.Models;
using Logic.Services;
using Presentation.Pages;
using System.Collections.ObjectModel;

namespace Presentation.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private ApplicationService mainService;
        private User mainUser;
        private Resume selectedResume;
        private ObservableCollection<Resume> resumes;
        private Vacancy selectedVacancy;
        private ObservableCollection<Vacancy> vacancies;
        private string errorMessage;

        public AdminViewModel()
        {
            DeleteItemCommand = new RellayCommand(DeleteItem);
            DeleteUserCommand = new RellayCommand(DeleteUser);
            RefreshPageCommand = new RellayCommand(RefreshPage);
            LogOutCommand = new RellayCommand(LogOut);
            mainService = ServiceConfiguration.GetMainService();

            InitializeAsync();
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
        public ObservableCollection<Resume> Resumes
        {
            get => resumes;
            set
            {
                resumes = value;
                OnPropertyChanged(nameof(Resumes));
            }
        }
        public ObservableCollection<Vacancy> Vacancies
        {
            get => vacancies;
            set
            {
                vacancies = value;
                OnPropertyChanged(nameof(Vacancies));
            }
        }

        public Resume SelectedResume
        {
            get => selectedResume;
            set
            {
                selectedResume = value;
                OnPropertyChanged(nameof(SelectedResume));
            }
        }

        public Vacancy SelectedVacancy
        {
            get => selectedVacancy;
            set
            {
                selectedVacancy = value;
                OnPropertyChanged(nameof(SelectedVacancy));
            }
        }

        public RellayCommand DeleteItemCommand { get; }
        public RellayCommand DeleteUserCommand { get; }
        public RellayCommand RefreshPageCommand { get; }
        public RellayCommand LogOutCommand { get; }


        private async void DeleteUser(object o)
        {
            if(SelectedResume!=null)
            {
                await mainService.userService.RemoveAsync(SelectedResume.UserId);
                await mainService.dataContext.SaveChangesAsync();
                App.AdminPage = new Admin();
                App.MainWindowViewModel.CurrentPage = App.AdminPage;
            }
            if (SelectedVacancy != null)
            {
                await mainService.userService.RemoveAsync(SelectedVacancy.UserId);
                await mainService.dataContext.SaveChangesAsync();
                App.AdminPage = new Admin();
                App.MainWindowViewModel.CurrentPage = App.AdminPage;
                return;
            }

            ErrorMessage = "Select Item";
        }

        private async void DeleteItem(object o)
        {
            if (SelectedResume != null)
            {
                await mainService.resumeService.RemoveAsync(SelectedResume.ResumeId);
                await mainService.dataContext.SaveChangesAsync();
                App.AdminPage = new Admin();
                App.MainWindowViewModel.CurrentPage = App.AdminPage;
                return;
            }
            if(SelectedVacancy!=null)
            {
                await mainService.vacancyService.RemoveAsync(SelectedVacancy.VacancyId);
                await mainService.dataContext.SaveChangesAsync();
                App.AdminPage = new Admin();
                App.MainWindowViewModel.CurrentPage = App.AdminPage;
                return;
            }
            ErrorMessage = "Select Item";
        }

        private void LogOut(object o)
        {
            CurrentUser.SetUserId(0);
            App.LoginPage = new Login();
            App.MainWindowViewModel.CurrentPage = App.LoginPage;
        }

        private void RefreshPage(object o)
        {
            App.AdminPage = new Admin();
            App.MainWindowViewModel.CurrentPage = App.AdminPage;
        }

        private async void InitializeAsync()
        {
            mainService = ServiceConfiguration.GetMainService();

            var resumes = mainService.resumeRepository.Get();
            if (resumes != null)
            {
                Resumes = new ObservableCollection<Resume>(resumes);
            }
            else
            {
                Resumes = new ObservableCollection<Resume>();
            }
            var vacancies = mainService.vacancyRepository.Get();
            if (vacancies != null)
            {
                Vacancies = new ObservableCollection<Vacancy>(vacancies);
            }
            else
            {
                Vacancies = new ObservableCollection<Vacancy>();
            }
        }
    }
}
