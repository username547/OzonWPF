using Ozon.DataManagers;
using Ozon.Model;
using Ozon.Patterns;
using Ozon.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Ozon.ViewModels
{
    public class ShopsViewModel : ViewModelBase
    {
        private ObservableCollection<ShopModel> _allShops;
        private Visibility _shopsTabVisibility = Visibility.Visible;

        public ShopsViewModel()
        {
            _allShops = new ObservableCollection<ShopModel>(ShopDataManager.GetAllShops());

            if (Singleton.Instance.Role != "Admin" && Singleton.Instance.Role != "Seller") _shopsTabVisibility = Visibility.Collapsed;
        }

        public ObservableCollection<ShopModel> AllShops
        {
            get { return _allShops; }
            set
            {
                _allShops = value;
                OnPropertyChanged(nameof(AllShops));
            }
        }

        public Visibility ShopsTabVisibility
        {
            get { return _shopsTabVisibility; }
            set
            {
                _shopsTabVisibility = value;
                OnPropertyChanged(nameof(ShopsTabVisibility));
            }
        }
    }
}
