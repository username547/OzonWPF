using Ozon.DataManage;
using Ozon.Model;
using Ozon.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ozon.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private readonly ObservableCollection<UserModel> _allUsers;
        public Window currentWindow;

        public AdminViewModel(Window currentWindow)
        {
            this.currentWindow = currentWindow;
            _allUsers = new ObservableCollection<UserModel>(UserDataManager.GetAllUsers());
        }
    }
}
