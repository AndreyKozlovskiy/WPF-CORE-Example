using Domain;
using Domain.Models;
using Logic.Services;
using Presentation.Pages;
using System.Collections.ObjectModel;
using System.Linq;

namespace Presentation.ViewModels
{
    public class MyVacanciesViewModel : ViewModelBase
    {
        private ApplicationService mainService;
        private ObservableCollection<Vacancy> vacancies;
        private Vacancy selectedVacancy;
        private string shortDescription;
        private string fullDescription;
        private string errorMessage;

        public MyVacanciesViewModel()
        {
            DeleteVacancyCommand = new RellayCommand(DeleteVacancy);
            AddVacancyCommand = new RellayCommand(AddVacancy);
            LogOutCommand = new RellayCommand(LogOut);
            GoAccountCommand = new RellayCommand(GoAccount);
            GoMyResumesCommand = new RellayCommand(GoMyResumes);
            GoMyVacanciesCommand = new RellayCommand(GoMyVacancies);
            GoSearchEmployeesCommand = new RellayCommand(GoSearchEmployees);
            GoSearchJobCommand = new RellayCommand(GoSearchJob);

            mainService = ServiceConfiguration.GetMainService();
            Vacancies =new ObservableCollection<Vacancy>
                (mainService.vacancyRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
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

        public Vacancy SelectedVacancy
        {
            get => selectedVacancy;
            set
            {
                selectedVacancy = value;
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

        public RellayCommand DeleteVacancyCommand { get; }
        public RellayCommand AddVacancyCommand { get; }
        public RellayCommand GoAccountCommand { get; }
        public RellayCommand LogOutCommand { get; }
        public RellayCommand GoMyVacanciesCommand { get; }
        public RellayCommand GoMyResumesCommand { get; }
        public RellayCommand GoSearchJobCommand { get; }
        public RellayCommand GoSearchEmployeesCommand { get; }

        public async void AddVacancy(object o)
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

            await mainService.vacancyRepository.AddAsync(new Vacancy()
            {
                FullDescription = FullDescription,
                ShortDescription = ShortDescription,
                UserId = CurrentUser.GetUserId(),
            });

            await mainService.dataContext.SaveChangesAsync();
            App.MyVacanciesPage = new MyVacancies();
            App.MainWindowViewModel.CurrentPage = App.MyVacanciesPage;
        }

        public async void DeleteVacancy(object o)
        {
            if (SelectedVacancy == null)
            {
                ErrorMessage = "Select Vacancy";
                return;
            }
            await mainService.vacancyRepository.RemoveAsync(SelectedVacancy.VacancyId);
            await mainService.dataContext.SaveChangesAsync();
            App.MyVacanciesPage = new MyVacancies();
            App.MainWindowViewModel.CurrentPage = App.MyVacanciesPage;
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
