using Ozon.Models.DTO;
using Ozon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ozon.Views
{
    /// <summary>
    /// Interaction logic for UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        public UpdateProductWindow(int productId, ProductDtoModel dto)
        {
            InitializeComponent();
            DataContext = new UpdateProductViewModel(this, productId, dto);
        }
    }
}
