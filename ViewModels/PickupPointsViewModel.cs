using Ozon.Commands;
using Ozon.DataManagers;
using Ozon.Model;
using Ozon.Models.QueryDTO;
using Ozon.Patterns;
using Ozon.ViewModel;
using Ozon.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModels
{
    public class PickupPointsViewModel : ViewModelBase
    {
        private ObservableCollection<PickupPointStatsDto> _allPickupPointStats;
        private PickupPointStatsDto? _selectedPickupPoint = null;
        public ICommand NavigateToStatisticsWindow { get; }

        private Visibility _pickupPointsTabVisibility = Visibility.Visible;
        private Visibility _pickupPointControlButtonsVisibility = Visibility.Visible;

        public PickupPointsViewModel()
        {
            _allPickupPointStats = new ObservableCollection<PickupPointStatsDto>(PickupPointDataManager.GetAllPickupPointsWithStats(Singleton.Instance.Id, Singleton.Instance.Role));
            NavigateToStatisticsWindow = new RelayCommand(parameter =>
                NavigateToStatisticsWindowExecute());

            if (Singleton.Instance.Role != "Admin" &&  Singleton.Instance.Role != "Employee")
            {
                _pickupPointsTabVisibility = Visibility.Collapsed;
                _pickupPointControlButtonsVisibility = Visibility.Collapsed;
            }
        }

        private void NavigateToStatisticsWindowExecute()
        {
            if (_selectedPickupPoint == null) return;
            StatisticsWindow statisticsWindow = new StatisticsWindow(_selectedPickupPoint.PickupPointId);
            statisticsWindow.Show();
        }

        public ObservableCollection<PickupPointStatsDto> AllPickupPointStats
        {
            get { return _allPickupPointStats; }
            set
            {
                _allPickupPointStats = value;
                OnPropertyChanged(nameof(AllPickupPointStats));
            }
        }

        public PickupPointStatsDto SelectedPickupPoint
        {
            get { return _selectedPickupPoint!; }
            set
            {
                _selectedPickupPoint = value;
                OnPropertyChanged(nameof(SelectedPickupPoint));
            }
        }

        public Visibility PickupPointsTabVisibility
        {
            get { return _pickupPointsTabVisibility; }
            set
            {
                _pickupPointsTabVisibility = value;
                OnPropertyChanged(nameof(PickupPointsTabVisibility));
            }
        }

        public Visibility PickupPointControlButtonsVisibility
        {
            get { return _pickupPointControlButtonsVisibility; }
            set
            {
                _pickupPointControlButtonsVisibility = value;
                OnPropertyChanged(nameof(PickupPointControlButtonsVisibility));
            }
        }
    }
}
