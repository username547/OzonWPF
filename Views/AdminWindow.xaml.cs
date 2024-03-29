using Ozon.ViewModels;
using System.Windows;

namespace Ozon.View
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            UsersTab.DataContext = new UsersViewModel();
            ShopsTab.DataContext = new ShopsViewModel();
            ProductsTab.DataContext = new ProductsViewModel();
            PickupPointsTab.DataContext = new PickupPointsViewModel();
            AccountTab.DataContext = new AccountViewModel(this);
        }
    }
}
