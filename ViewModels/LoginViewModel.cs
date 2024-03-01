using Ozon.Commands;
using Ozon.DataManage;
using Ozon.Model.DTO;
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
            if (ValidateLogin() && UserDataManager.ComparePassword(
                _loginDtoModel.UserEmail,
                _loginDtoModel.UserPassword)) MessageBox.Show("Hello");
            else MessageBox.Show("Error!");
        }

        public bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(_loginDtoModel.UserEmail) ||
                string.IsNullOrEmpty(_loginDtoModel.UserPassword)) return false;

            return true;
        }
    }
}
