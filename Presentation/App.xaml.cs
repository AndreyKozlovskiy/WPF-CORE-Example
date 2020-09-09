using Presentation.Pages;
using Presentation.ViewModels;
using System.Windows;

namespace Presentation
{
    public partial class App : Application
    {
        public static MainWindowViewModel MainWindowViewModel { get; set; } = new MainWindowViewModel();
        
        public static Login LoginPage=new Login();
        public static Admin AdminPage;
        public static Register RegisterPage;
        public static Account AccountPage;
        public static MyResumes MyResumesPage;
        public static MyVacancies MyVacanciesPage;
        public static SearchEmployees SearchEmployeesPage;
        public static SearchJob SearchJobPage;
    }
}