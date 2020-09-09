using System.Windows;
using System.Windows.Controls;

namespace Presentation.Pages
{
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
        }

        private void PasswordBox_OldPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).OldPassword = ((PasswordBox)sender).Password;
            }
        }
        
        private void PasswordBox_ConfirmPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).ConfirmPassword = ((PasswordBox)sender).Password;
            }
        }
        
        private void PasswordBox_NewPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).NewPassword = ((PasswordBox)sender).Password;
            }
        }
        
        private void PasswordBox_PasswordToDeleteChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).PasswordToDelete = ((PasswordBox)sender).Password;
            }
        }
    }
}
