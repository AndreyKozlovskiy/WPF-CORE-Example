using Domain;
using Domain.Models;
using Logic.Services;
using Presentation.Pages;
using System.Collections.ObjectModel;
using System.Linq;

namespace Presentation.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private ObservableCollection<Skill> skills;
        private ObservableCollection<Education> educations;
        private ObservableCollection<WorkExperience> workExperiences;
        private Skill selectedSkill;
        private Education selectedEducation;
        private WorkExperience selectedWorkExperience;
        private ApplicationService mainService;
        private User user;
        private string errorMessage;
        private string skillName;
        private string educationName;
        private string educationOrghanization;
        private string workName;
        private string workOrghanization;

        public AccountViewModel()
        {
            mainService = ServiceConfiguration.GetMainService();

            AddEducationCommand = new RellayCommand(AddEducation);
            AddSkillCommand = new RellayCommand(AddSkill);
            DeleteItemCommand = new RellayCommand(DeleteItem);
            AddWorkCommand = new RellayCommand(AddWork);
            DeleteAccountCommand = new RellayCommand(DeleteAccount);
            ChangePasswordCommand = new RellayCommand(ChangePassword);
            ChangeAccountSettingsCommand = new RellayCommand(ChangeAccountSettings);
            LogOutCommand = new RellayCommand(LogOut);
            GoAccountCommand = new RellayCommand(GoAccount);
            GoMyResumesCommand = new RellayCommand(GoMyResumes);
            GoMyVacanciesCommand = new RellayCommand(GoMyVacancies);
            GoSearchEmployeesCommand = new RellayCommand(GoSearchEmployees);
            GoSearchJobCommand = new RellayCommand(GoSearchJob);

            User = mainService.userService.Get(CurrentUser.GetUserId());

            Skills = new ObservableCollection<Skill>
                (mainService.skillRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
            WorkExperiences = new ObservableCollection<WorkExperience>
                (mainService.workExperienceRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
            Educations = new ObservableCollection<Education>
                (mainService.educationRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
        }

        public string WorkName
        {
            get => workName;
            set
            {
                workName = value;
                OnPropertyChanged(nameof(WorkName));
            }
        }
        public string WorkOrghanization
        {
            get => workOrghanization;
            set
            {
                workOrghanization = value;
                OnPropertyChanged(nameof(WorkOrghanization));
            }
        }
        public string SkillName
        {
            get => skillName;
            set
            {
                skillName = value;
                OnPropertyChanged(nameof(SkillName));
            }
        }
        public string EducationOrganization
        {
            get => educationOrghanization;
            set
            {
                educationOrghanization = value;
                OnPropertyChanged(nameof(EducationOrganization));
            }
        }
        public string EducationName
        {
            get => educationName;
            set
            {
                educationName = value;
                OnPropertyChanged(nameof(EducationName));
            }
        }
        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
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
        public ObservableCollection<Skill> Skills
        {
            get => skills;
            set
            {
                skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }
        public Skill SelectedSkill
        {
            get => selectedSkill;
            set
            {
                selectedSkill = value;
                OnPropertyChanged(nameof(SelectedSkill));
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
        public Education SelectedEducation
        {
            get => selectedEducation;
            set
            {
                selectedEducation = value;
                OnPropertyChanged(nameof(SelectedEducation));
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
        public WorkExperience SelectedWorkExperience
        {
            get => selectedWorkExperience;
            set
            {
                selectedWorkExperience = value;
                OnPropertyChanged(nameof(SelectedWorkExperience));
            }
        }

        public string OldPassword { private get; set; }
        public string NewPassword { private get; set; }
        public string ConfirmPassword { private get; set; }
        public string PasswordToDelete { private get; set; }

        public RellayCommand AddSkillCommand { get; }
        public RellayCommand AddEducationCommand { get; }
        public RellayCommand DeleteAccountCommand { get; }
        public RellayCommand AddWorkCommand { get; }
        public RellayCommand DeleteItemCommand { get; }
        public RellayCommand ChangePasswordCommand { get; }
        public RellayCommand ChangeAccountSettingsCommand { get; }
        public RellayCommand GoAccountCommand { get; }
        public RellayCommand LogOutCommand { get; }
        public RellayCommand GoMyVacanciesCommand { get; }
        public RellayCommand GoMyResumesCommand { get; }
        public RellayCommand GoSearchJobCommand { get; }
        public RellayCommand GoSearchEmployeesCommand { get; }


        private async void AddEducation(object o)
        {
            if (string.IsNullOrEmpty(EducationName))
            {
                ErrorMessage = "Enter Education";
                return;
            }
            if (string.IsNullOrEmpty(EducationOrganization))
            {
                ErrorMessage = "Enter Organization";
                return;
            }

            if (Educations.FirstOrDefault(x => x.EducationName == EducationName && x.OrghanisationName == EducationOrganization) != null)
            {
                ErrorMessage = "This Education has already added";
                return;
            }
        
            await mainService.educationService.AddAsync(new Education()
            {
                EducationName = EducationName,
                OrghanisationName = EducationOrganization,
                UserId = CurrentUser.GetUserId(),
            });
            EducationName = "";
            EducationOrganization = "";
            ErrorMessage = "";
            await mainService.dataContext.SaveChangesAsync();
            Educations = new ObservableCollection<Education>(mainService.educationRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
        }

        private async void AddWork(object o)
        {
            if (string.IsNullOrEmpty(WorkName))
            {
                ErrorMessage = "Enter Your Position";
                return;
            }
            if (string.IsNullOrEmpty(WorkOrghanization))
            {
                ErrorMessage = "Enter Organization Of Work";
                return;
            }

            if (WorkExperiences.FirstOrDefault(x => x.WorkName == WorkName && x.OrghanizationName == WorkOrghanization) != null)
            {
                ErrorMessage = "This Experience has already added";
                return;
            }

            await mainService.workExperienceService.AddAsync(new WorkExperience()
            {
                WorkName = WorkName,
                OrghanizationName = WorkOrghanization,
                UserId = CurrentUser.GetUserId(),
            });
            await mainService.dataContext.SaveChangesAsync();
            WorkName = "";
            WorkOrghanization = "";
            ErrorMessage = "";
            WorkExperiences = new ObservableCollection<WorkExperience>(mainService.workExperienceRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
        }

        private async void AddSkill(object o)
        {
            if (string.IsNullOrEmpty(SkillName))
            {
                ErrorMessage = "Enter Skill";
                return;
            }
            if (Skills.FirstOrDefault(x => x.SkillName == SkillName) != null)
            {
                ErrorMessage = "This Skill has already added";
                return;
            }

            await mainService.skillService.AddAsync(new Skill()
            {
                SkillName = SkillName,
                UserId = CurrentUser.GetUserId(),
            });
            await mainService.dataContext.SaveChangesAsync();
            SkillName = "";
            ErrorMessage = "";
            Skills = new ObservableCollection<Skill>(mainService.skillRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
        }

        private async void ChangeAccountSettings(object o)
        {
            await mainService.dataContext.SaveChangesAsync();
            ErrorMessage = "Changes were saved";
        }

        private async void DeleteItem(object o)
        {
            if (SelectedEducation != null)
            {
                await mainService.educationService.RemoveAsync(SelectedEducation.Id);
                await mainService.dataContext.SaveChangesAsync();

                Educations = new ObservableCollection<Education>(mainService.educationRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
                return;
            }
            if (SelectedSkill != null)
            {
                await mainService.skillService.RemoveAsync(SelectedSkill.SkillId);
                await mainService.dataContext.SaveChangesAsync();
                Skills = new ObservableCollection<Skill>(mainService.skillRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
                return;
            }
            if (SelectedWorkExperience != null)
            {
                await mainService.workExperienceService.RemoveAsync(SelectedWorkExperience.Id);
                await mainService.dataContext.SaveChangesAsync();
                WorkExperiences = new ObservableCollection<WorkExperience>(mainService.workExperienceRepository.Get().Where(x => x.UserId == CurrentUser.GetUserId()));
                return;
            }
            ErrorMessage = "Select Item First";
        }

        private async void ChangePassword(object o)
        {
            if (string.IsNullOrEmpty(OldPassword))
            {
                ErrorMessage = "Enter your password";
                return;
            }
            if (string.IsNullOrEmpty(NewPassword))
            {
                ErrorMessage = "Enter your new Password";
                return;
            }
            if (NewPassword.Length < 6)
            {
                ErrorMessage = "Short new Password";
                return;
            }
            if (NewPassword == OldPassword)
            {
                ErrorMessage = "Old and New Passwords are equal";
                return;
            }
            if (NewPassword != ConfirmPassword)
            {
                ErrorMessage = "Passwords don't match";
                return;
            }

            var isAllowed = mainService.DecryptPassword(User.Password, OldPassword);

            if (isAllowed)
            {
                User.Password = mainService.EncryptPassword(NewPassword);

                await mainService.dataContext.SaveChangesAsync();
                ErrorMessage = "Password has been changed";
                OldPassword = "";
                NewPassword = "";
                ConfirmPassword = "";
                return;
            }

            ErrorMessage = "Wrong Password";
        }

        private async void DeleteAccount(object o)
        {
            if (string.IsNullOrEmpty(PasswordToDelete))
            {
                ErrorMessage = "Enter Password";
                return;
            }

            var isAllowed = mainService.DecryptPassword(User.Password, PasswordToDelete);

            if (isAllowed)
            {
                CurrentUser.SetUserId(0);
                App.LoginPage = new Login();
                App.MainWindowViewModel.CurrentPage = App.LoginPage;
                await mainService.userService.RemoveAsync(User.Id);
                await mainService.dataContext.SaveChangesAsync();
                return;
            }
            ErrorMessage = "Wrong Password";
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
