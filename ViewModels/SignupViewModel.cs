using Ozon.Commands;
using Ozon.DataManage;
using Ozon.Model.DTO;
using Ozon.Views;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModel
{
    public class SignupViewModel : ViewModelBase
    {
        private readonly SignupDtoModel _signupDtoModel;
        public Window currentWindow;
        public ICommand SignupCommand { get; }
        public ICommand NavigateToLoginWindowCommand { get; }

        public SignupViewModel(Window currentWindow)
        {
            _signupDtoModel = new SignupDtoModel();
            this.currentWindow = currentWindow;
            SignupCommand = new RelayCommand(parameter => Signup());
            NavigateToLoginWindowCommand = new RelayCommand(parameter => NavigateToLoginWindow());
        }

        public void NavigateToLoginWindow()
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            currentWindow.Close();
        }

        public string UserName
        {
            get => _signupDtoModel.UserName;
            set
            {
                _signupDtoModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string UserSurname
        {
            get => _signupDtoModel.UserSurname;
            set
            {
                _signupDtoModel.UserSurname = value;
                OnPropertyChanged(nameof(UserSurname));
            }
        }

        public string UserEmail
        {
            get => _signupDtoModel.UserEmail;
            set
            {
                _signupDtoModel.UserEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        public string UserPassword
        {
            get => _signupDtoModel.UserPassword;
            set
            {
                _signupDtoModel.UserPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        public string UserPasswordConfirm
        {
            get => _signupDtoModel.UserPasswordConfirm;
            set
            {
                _signupDtoModel.UserPasswordConfirm = value;
                OnPropertyChanged(nameof(UserPasswordConfirm));
            }
        }   

        public void Signup()
        {
            if (ValidateSignup() && UserDataManager.CreateUser(
                _signupDtoModel.UserName,
                _signupDtoModel.UserSurname,
                _signupDtoModel.UserEmail,
                _signupDtoModel.UserPassword)) NavigateToLoginWindow();
            else MessageBox.Show("Error!");
        }

        public bool ValidateSignup()
        {
            if (string.IsNullOrEmpty(_signupDtoModel.UserName) ||
                string.IsNullOrEmpty(_signupDtoModel.UserSurname) ||
                string.IsNullOrEmpty(_signupDtoModel.UserEmail) ||
                string.IsNullOrEmpty(_signupDtoModel.UserPassword) ||
                string.IsNullOrEmpty(_signupDtoModel.UserPasswordConfirm)) { MessageBox.Show("Empty Field"); return false; }

            if (!string.Equals(_signupDtoModel.UserPassword, _signupDtoModel.UserPasswordConfirm)) { MessageBox.Show("Invalid Password"); return false; }

            return true;
        }
    }
}
