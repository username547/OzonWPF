using Ozon.ViewModels;
using System.Windows;

namespace Ozon.Views
{
    /// <summary>
    /// Interaction logic for CreateProductWindow.xaml
    /// </summary>
    public partial class CreateProductWindow : Window
    {
        public CreateProductWindow()
        {
            InitializeComponent();
            DataContext = new CreateProductViewModel(this);
        }
    }
}
