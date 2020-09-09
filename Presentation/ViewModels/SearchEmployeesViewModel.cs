using Domain;
using Domain.Models;
using Logic.Services;
using Presentation.Pages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Presentation.ViewModels
{
    public class SearchEmployeesViewModel:ViewModelBase
    {
        private ApplicationService mainService;
        private ObservableCollection<Resume> resumes;
        private ObservableCollection<Skill> skills;
        private ObservableCollection<Education> educations;
        private ObservableCollection<WorkExperience> workExperiences;
        private string mail;
        private string city;
        private string firstName;
        private string secondName;
        private Resume selectedResume;

        public SearchEmployeesViewModel()
        {
            ShowUserCommand = new RellayCommand(ShowUser);
            LogOutCommand = new RellayCommand(LogOut);
            GoAccountCommand = new RellayCommand(GoAccount);
            GoMyResumesCommand = new RellayCommand(GoMyResumes);
            GoMyVacanciesCommand = new RellayCommand(GoMyVacancies);
            GoSearchEmployeesCommand = new RellayCommand(GoSearchEmployees);
            GoSearchJobCommand = new RellayCommand(GoSearchJob);
            mainService = ServiceConfiguration.GetMainService();

            Resumes = new ObservableCollection<Resume>(mainService.resumeRepository.Get());
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
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }

        public ObservableCollection<Skill> Skills
        {
            get => skills;
            set
            {
                skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }
        public ObservableCollection<Education> Educations
        {
            get => educations;
            set
            {
                educations = value;
                OnPropertyChanged(nameof(Educations));
            }
        }
        public ObservableCollection<WorkExperience> WorkExperiences
        {
            get => workExperiences;
            set
            {
                workExperiences = value;
                OnPropertyChanged(nameof(WorkExperiences));
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

        public ObservableCollection<Resume> Resumes
        {
            get => resumes;
            set
            {
                resumes = value;
                OnPropertyChanged(nameof(Resumes));
            }
        }

        public RellayCommand ShowUserCommand { get; }
        public RellayCommand GoAccountCommand { get; }
        public RellayCommand LogOutCommand { get; }
        public RellayCommand GoMyVacanciesCommand { get; }
        public RellayCommand GoMyResumesCommand { get; }
        public RellayCommand GoSearchJobCommand { get; }
        public RellayCommand GoSearchEmployeesCommand { get; }

        private void ShowUser(object o)
        {
            if(selectedResume==null)
            {
                MessageBox.Show("Select resume");
            }
            var user = mainService.userService.Get(selectedResume.UserId);
            Mail = user.Mail;
            City = user.City;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            var skills = mainService.skillRepository.Get().Where(x => x.UserId == user.Id);
            var educations = mainService.educationRepository.Get().Where(x => x.UserId == user.Id);
            var workExperiences = mainService.workExperienceRepository.Get().Where(x => x.UserId == user.Id);

            if (skills != null)
            {
                Skills = new ObservableCollection<Skill>(skills);
            }
            if (workExperiences != null)
            {
                WorkExperiences = new ObservableCollection<WorkExperience>(workExperiences);
            }
            if (educations != null)
            {
                Educations = new ObservableCollection<Education>(educations);
            }
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