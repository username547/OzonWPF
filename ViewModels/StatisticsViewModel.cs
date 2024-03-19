using Ozon.Commands;
using Ozon.DataManagers;
using Ozon.Models.QueryDTO;
using Ozon.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModels
{
    public class StatisticsViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeStatsDto> _allEmployeeStats;
        private Window _currentWindow;
        private int _pickupPointId;
        public ICommand CloseStats { get; }

        public StatisticsViewModel(Window currentWindow, int pickupPointId)
        {
            _currentWindow = currentWindow;
            _pickupPointId = pickupPointId;
            _allEmployeeStats = new ObservableCollection<EmployeeStatsDto>(EmployeeDataManager.GetAllEmployeesWithStats(_pickupPointId));
            CloseStats = new RelayCommand(parameter =>
                CloseStatsExecute());
        }

        private void CloseStatsExecute() => _currentWindow.Close();

        public ObservableCollection<EmployeeStatsDto> AllEmployeeStats
        {
            get { return _allEmployeeStats; }
            set
            {
                _allEmployeeStats = value;
                OnPropertyChanged(nameof(AllEmployeeStats));
            }
        }
    }
}
