using Microsoft.VisualBasic.ApplicationServices;
using Ozon.Model.Data;
using Ozon.Model.DTO;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModel
{
    public class SignupViewModel : ViewModelBase
    {
        private SignupModel dto;
        public ICommand SignupCommand { get; }

        public SignupViewModel()
        {
            dto = new SignupModel();
            SignupCommand = new RelayCommand(param => Signup());
        }

        public string UserName
        {
            get => dto.UserName;
            set
            {
                dto.UserName = value;
                OnPropertyChanged(nameof(dto.UserName));
            }
        }

        public string UserSurname
        {
            get => dto.UserSurname;
            set
            {
                dto.UserSurname = value;
                OnPropertyChanged(nameof(dto.UserSurname));
            }
        }

        public string UserEmail
        {
            get => dto.UserEmail;
            set
            {
                dto.UserEmail = value;
                OnPropertyChanged(nameof(dto.UserEmail));
            }
        }

        public string UserPassword
        {
            get => dto.UserPassword;
            set
            {
                dto.UserPassword = value;
                OnPropertyChanged(nameof(dto.UserPassword));
            }
        }

        public string UserPasswordConfirm
        {
            get => dto.UserPassword;
            set
            {
                dto.UserPassword = value;
                OnPropertyChanged(nameof(dto.UserPassword));
            }
        }   

        public void Signup()
        {
            if (!UserDataManager.CreateUser(dto.UserName, dto.UserSurname, dto.UserEmail, dto.UserPassword)) MessageBox.Show("Good");
            else MessageBox.Show("Bad");
        }

        public bool CanSignup()
        {
            if (string.IsNullOrEmpty(dto.UserName) ||
                string.IsNullOrEmpty(dto.UserSurname) ||
                string.IsNullOrEmpty(dto.UserEmail) ||
                string.IsNullOrEmpty(dto.UserPassword) ||
                string.IsNullOrEmpty(dto.UserPasswordConfirm)) return false;

            if (!string.Equals(dto.UserPassword, dto.UserPasswordConfirm)) return false;

            return true;
        }

        private void LoggedIn(object parameter)
        {
            MessageBox.Show($"Logged in successfull as {parameter}");
        }
    }
}
