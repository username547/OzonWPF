using Ozon.Commands;
using Ozon.DataManage;
using Ozon.DataManagers;
using Ozon.Model;
using Ozon.Models.DTO;
using Ozon.ViewModel;
using Ozon.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private ObservableCollection<ShopModel> _allShops;
        public Window currentWindow;

        public ICommand NavigateToStatisticsWindow { get; }

        public AdminViewModel(Window currentWindow)
        {
            this.currentWindow = currentWindow;
            _allShops = new ObservableCollection<ShopModel>(ShopDataManager.GetAllShops());
            NavigateToStatisticsWindow = new RelayCommand(parameter =>
            {
                StatisticsWindow statisticsWindow = new StatisticsWindow();
                statisticsWindow.Show();
            });
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
    }
}
