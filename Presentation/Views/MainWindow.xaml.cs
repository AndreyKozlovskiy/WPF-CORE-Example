using System.Windows;

namespace Presentation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = App.MainWindowViewModel;
            App.MainWindowViewModel.CurrentPage = App.LoginPage;
            InitializeComponent();
        }
    }
}