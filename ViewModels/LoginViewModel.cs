using Ozon.Commands;
using Ozon.DataManage;
using Ozon.Model.DTO;
using Ozon.Patterns;
using Ozon.View;
using Ozon.ViewModel;
using Ozon.Views;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly LoginDtoModel _loginDtoModel;
        public Window currentWindow;
        public ICommand LoginCommand { get; }
        public ICommand NavigateToSignupWindowCommand { get; }

        public LoginViewModel(Window currentWindow)
        {
            _loginDtoModel = new LoginDtoModel();
            this.currentWindow = currentWindow;
            LoginCommand = new RelayCommand(parameter => Login());
            NavigateToSignupWindowCommand = new RelayCommand(parameter => NavigateToSignupWindow());
        }

        public void NavigateToSignupWindow()
        {
            SignupWindow window = new SignupWindow();
            window.Show();
            currentWindow.Close();
        }

        public void NavigateToAdminWindow()
        {
            AdminWindow window = new AdminWindow();
            window.Show();
            currentWindow.Close();
        }

        public string UserEmail
        {
            get => _loginDtoModel.UserEmail;
            set
            {
                _loginDtoModel.UserEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        public string UserPassword
        {
            get => _loginDtoModel.UserPassword;
            set
            {
                _loginDtoModel.UserPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        public void Login()
        {
            if (!ValidateLogin() || !UserDataManager.ComparePassword(
                _loginDtoModel.UserEmail,
                _loginDtoModel.UserPassword))
            {
                MessageBox.Show("Incorrect Login or Password");
                return;
            }

            var user = UserDataManager.GetUserByEmail(UserEmail);
            if (user == null)
            {
                MessageBox.Show("Incorrect Email");
                return;
            }

            string? role = UserDataManager.GetRoleName(user.RoleId);
            if (role == null)
            {
                MessageBox.Show("Incorrect User");
                return;
            }

            Singleton.Instance.Id = user.UserId;
            Singleton.Instance.Email = user.UserEmail;
            Singleton.Instance.Role = role!;

            NavigateToAdminWindow();
        }

        public bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(_loginDtoModel.UserEmail) ||
                string.IsNullOrEmpty(_loginDtoModel.UserPassword)) return false;

            return true;
        }
    }
}
