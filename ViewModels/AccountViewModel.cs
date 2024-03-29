using Ozon.Commands;
using Ozon.ViewModel;
using Ozon.Views;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private Window _adminWindow;
        public ICommand Logout { get; }

        public AccountViewModel(Window adminWindow)
        {
            _adminWindow = adminWindow;
            Logout = new RelayCommand(parameter =>
                LogoutExecute());
        }

        private void LogoutExecute()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            _adminWindow.Close();
        }
    }
}
