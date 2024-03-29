using Ozon.DataManage;
using Ozon.Model;
using Ozon.Patterns;
using Ozon.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Ozon.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        private ObservableCollection<UserModel> _allUsers;
        private Visibility _usersTabVisibility = Visibility.Visible;

        public UsersViewModel()
        {
            _allUsers = new ObservableCollection<UserModel>(UserDataManager.GetAllUsers());

            if (Singleton.Instance.Role != "Admin") _usersTabVisibility = Visibility.Collapsed;
        }

        public ObservableCollection<UserModel> AllUsers
        {
            get { return _allUsers; }
            set
            {
                _allUsers = value;
                OnPropertyChanged(nameof(AllUsers));
            }
        }

        public Visibility UsersTabVisibility
        {
            get { return _usersTabVisibility; }
            set
            {
                _usersTabVisibility = value;
                OnPropertyChanged(nameof(UsersTabVisibility));
            }
        }

        public void UsersTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool isVisible)
            {
                UsersTabVisibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
