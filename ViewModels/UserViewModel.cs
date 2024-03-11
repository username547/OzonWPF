using Ozon.DataManage;
using Ozon.Model;
using Ozon.ViewModel;
using System.Collections.ObjectModel;

namespace Ozon.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private ObservableCollection<UserModel> _allUsers;

        public UserViewModel()
        {
            _allUsers = new ObservableCollection<UserModel>(UserDataManager.GetAllUsers());
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
    }
}
