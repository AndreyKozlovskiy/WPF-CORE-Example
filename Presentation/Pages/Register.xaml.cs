using System.Windows;
using System.Windows.Controls;

namespace Presentation.Pages
{
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext!=null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
        private void PasswordBox_ConfirmPasswordChanged(object sender, RoutedEventArgs e)
        {
            if(DataContext!=null)
            {
                ((dynamic)DataContext).ConfirmPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}
