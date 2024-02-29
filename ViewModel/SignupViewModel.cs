using Microsoft.VisualBasic.ApplicationServices;
using Ozon.Model;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModel
{
    public class SignupViewModel : ViewModelBase
    {
        private UserModel newUser;
        public ICommand LoginCommand { get; }

        public SignupViewModel()
        {
            newUser = new UserModel();
            LoginCommand = new RelayCommand((param) => LoggedIn(param));
        }

        public string UserName
        {
            get => newUser.UserName;
            set
            {
                newUser.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string UserSurname
        {
            get => newUser.UserSurname;
            set
            {
                newUser.UserSurname = value;
                OnPropertyChanged(nameof(UserSurname));
            }
        }

        public string UserEmail
        {
            get => newUser.UserEmail;
            set
            {
                newUser.UserEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        public string UserPassword
        {
            get => newUser.UserPassword;
            set
            {
                newUser.UserPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        private void LoggedIn(object parameter)
        {
            MessageBox.Show($"Logged in successfull as {parameter}");
        }
    }
}
