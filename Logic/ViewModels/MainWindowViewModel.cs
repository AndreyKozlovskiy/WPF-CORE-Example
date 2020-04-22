using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Logic.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int clicks;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public int Clicks
        {
            get { return clicks; }
            set
            {
                clicks = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddClick
        {
            get
            {
                return new DelegateCommand((obj) =>
               {
                   Clicks++;
               });
            }
        }

        public MainWindowViewModel()
        {
            Clicks = 10;
        }

    }
}
