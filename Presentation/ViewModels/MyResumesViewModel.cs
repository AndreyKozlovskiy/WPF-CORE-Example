using Domain;
using Domain.Models;
using Logic.Services;
using Presentation.Pages;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Presentation.ViewModels
{
    public class MyResumesViewModel : ViewModelBase
    {
        private ApplicationService mainService;
        private ObservableCollection<Resume> resumes;
        private Resume selectedResume;
        private string shortDescription;
        private string fullDescription;
        private string errorMessage;

        public MyResumesViewModel()
        {
            AddResumeCommand = new RellayCommand(AddResume);
            DeleteResumeCommand = new RellayCommand(DeleteResume);
            LogOutCommand = new RellayCommand(LogOut);
            GoAccountCommand = new RellayCommand(GoAccount);
            GoMyResumesCommand = new RellayCommand(GoMyResumes);
            GoMyVacanciesCommand = new RellayCommand(GoMyVacancies);
            GoSearchEmployeesCommand = new RellayCommand(GoSearchEmployees);
            GoSearchJobCommand = new RellayCommand(GoSearchJob);

            mainService = ServiceConfiguration.GetMainService();

            var userResumes = mainService.resumeRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId());
            Resumes = new ObservableCollection<Resume>(userResumes);
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

        public Resume SelectedResume
        {
            get => selectedResume;
            set
            {
                selectedResume = value;
                OnPropertyChanged();
            }
        }

        public string ShortDescription
        {
            get => shortDescription;
            set
            {
                shortDescription = value;
                OnPropertyChanged(nameof(ShortDescription));
            }
        }

        public string FullDescription
        {
            get => fullDescription;
            set
            {
                fullDescription = value;
                OnPropertyChanged(nameof(FullDescription));
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

        public RellayCommand DeleteResumeCommand { get; }
        public RellayCommand AddResumeCommand { get; }
        public RellayCommand GoAccountCommand { get; }
        public RellayCommand LogOutCommand { get; }
        public RellayCommand GoMyVacanciesCommand { get; }
        public RellayCommand GoMyResumesCommand { get; }
        public RellayCommand GoSearchJobCommand { get; }
        public RellayCommand GoSearchEmployeesCommand { get; }

        public async void AddResume(object o)
        {
            if (string.IsNullOrEmpty(ShortDescription))
            {
                ErrorMessage = "Enter Name";
                return;
            }
            if (string.IsNullOrEmpty(FullDescription))
            {
                ErrorMessage = "Enter Full Description";
                return;
            }

            await mainService.resumeRepository.AddAsync(new Resume()
            {
                FullDescription = FullDescription,
                ShortDescription = ShortDescription,
                UserId = CurrentUser.GetUserId(),
            });

            await mainService.dataContext.SaveChangesAsync();
            App.MyResumesPage = new MyResumes();
            App.MainWindowViewModel.CurrentPage = App.MyResumesPage;
        }

        public async void DeleteResume(object o)
        {
            if (SelectedResume == null)
            {
                ErrorMessage = "Select Vacancy";
                return;
            }
            await mainService.resumeService.RemoveAsync(SelectedResume.ResumeId);
            await mainService.dataContext.SaveChangesAsync();
            App.MyResumesPage = new MyResumes();
            App.MainWindowViewModel.CurrentPage = App.MyResumesPage;
        }

        private void LogOut(object o)
        {
            CurrentUser.SetUserId(0);
            App.LoginPage = new Login();
            App.MainWindowViewModel.CurrentPage = App.LoginPage;
        }

        private void GoMyVacancies(object o)
        {
            App.MyVacanciesPage = new MyVacancies();
            App.MainWindowViewModel.CurrentPage = App.MyVacanciesPage;
        }

        private void GoMyResumes(object o)
        {
            App.MyResumesPage = new MyResumes();
            App.MainWindowViewModel.CurrentPage = App.MyResumesPage;
        }

        private void GoSearchEmployees(object O)
        {
            App.SearchEmployeesPage = new SearchEmployees();
            App.MainWindowViewModel.CurrentPage = App.SearchEmployeesPage;
        }

        private void GoSearchJob(object o)
        {
            App.SearchJobPage = new SearchJob();
            App.MainWindowViewModel.CurrentPage = App.SearchJobPage;
        }

        private void GoAccount(object o)
        {
            App.AccountPage = new Account();
            App.MainWindowViewModel.CurrentPage = App.AccountPage;
        }
    }
}
