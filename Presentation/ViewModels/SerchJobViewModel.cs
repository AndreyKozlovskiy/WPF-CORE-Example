using Domain;
using Domain.Models;
using Logic.Services;
using Presentation.Pages;
using System.Collections.ObjectModel;

namespace Presentation.ViewModels
{
    public class SerchJobViewModel :ViewModelBase
    {
        private ApplicationService mainService;
        private ObservableCollection<Vacancy> vacancies;
        public SerchJobViewModel()
        {
            GoHomeCommand = new RellayCommand(GoHome);
            LogOutCommand = new RellayCommand(LogOut);
            GoAccountCommand = new RellayCommand(GoAccount);
            GoMyResumesCommand = new RellayCommand(GoMyResumes);
            GoMyVacanciesCommand = new RellayCommand(GoMyVacancies);
            GoSearchEmployeesCommand = new RellayCommand(GoSearchEmployees);
            GoSearchJobCommand = new RellayCommand(GoSearchJob);

            mainService = ServiceConfiguration.GetMainService();

            Vacancies = new ObservableCollection<Vacancy>(mainService.vacancyRepository.Get());
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

        public RellayCommand GoAccountCommand { get; }
        public RellayCommand LogOutCommand { get; }
        public RellayCommand GoHomeCommand { get; }
        public RellayCommand GoMyVacanciesCommand { get; }
        public RellayCommand GoMyResumesCommand { get; }
        public RellayCommand GoSearchJobCommand { get; }
        public RellayCommand GoSearchEmployeesCommand { get; }

        private void GoHome(object o)
        {
            App.AdminPage = new Admin();
            App.MainWindowViewModel.CurrentPage = App.AdminPage;
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
