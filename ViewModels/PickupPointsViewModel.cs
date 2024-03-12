using Ozon.DataManagers;
using Ozon.Model;
using Ozon.ViewModel;
using System.Collections.ObjectModel;

namespace Ozon.ViewModels
{
    public class PickupPointsViewModel : ViewModelBase
    {
        private ObservableCollection<PickupPointModel> _allPickupPoints;

        public PickupPointsViewModel()
        {
            _allPickupPoints = new ObservableCollection<PickupPointModel>(PickupPointDataManager.GetAllPickupPoints());
        }

        public ObservableCollection<PickupPointModel> AllPickupPoints
        {
            get { return _allPickupPoints; }
            set
            {
                _allPickupPoints = value;
                OnPropertyChanged(nameof(AllPickupPoints));
            }
        }
    }
}
