using Ozon.Commands;
using Ozon.Model.DTO;
using Ozon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ozon.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly LoginDtoModel _loginDtoModel;
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _loginDtoModel = new LoginDtoModel();
            LoginCommand = new RelayCommand(parameter => Login());
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

        }

        public bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(_loginDtoModel.UserEmail) ||
                string.IsNullOrEmpty(_loginDtoModel.UserPassword)) return false;

            return true;
        }
    }
}
