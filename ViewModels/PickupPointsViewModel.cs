using Ozon.Commands;
using Ozon.DataManagers;
using Ozon.Model;
using Ozon.Models.QueryDTO;
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

        public PickupPointsViewModel()
        {
            _allPickupPointStats = new ObservableCollection<PickupPointStatsDto>(PickupPointDataManager.GetAllPickupPointsWithStats());
            NavigateToStatisticsWindow = new RelayCommand(parameter =>
                NavigateToStatisticsWindowExecute());
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
    }
}
