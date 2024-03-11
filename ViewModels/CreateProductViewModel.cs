using Ozon.Commands;
using Ozon.DataManagers;
using Ozon.Models.DTO;
using Ozon.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ozon.ViewModels
{
    public class CreateProductViewModel : ViewModelBase
    {
        private readonly ProductDtoModel _productDtoModel;
        public Window currentWindow;
        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateProductViewModel(Window currentWindow)
        {
            _productDtoModel = new ProductDtoModel();
            this.currentWindow = currentWindow;
            CreateCommand = new RelayCommand(parameter =>
                CreateCommandExecute());
            CancelCommand = new RelayCommand(parameter => currentWindow.Close());
        }

        private void CreateCommandExecute()
        {
            ProductDataManager.CreateProduct(_productDtoModel);
            currentWindow.Close();
        }

        public string ProductName
        {
            get => _productDtoModel.ProductName;
            set
            {
                _productDtoModel.ProductName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public string ProductDescription
        {
            get => _productDtoModel.ProductDescription;
            set
            {
                _productDtoModel.ProductDescription = value;
                OnPropertyChanged(nameof(ProductDescription));
            }
        }

        public string ProductPrice
        {
            get => Convert.ToString(_productDtoModel.ProductPrice);
            set
            {
                _productDtoModel.ProductPrice = Convert.ToInt32(value);
                OnPropertyChanged(nameof(ProductPrice));
            }
        }

        public string ProductRating
        {
            get => Convert.ToString(_productDtoModel.ProductRating);
            set
            {
                _productDtoModel.ProductRating = Convert.ToInt32(value);
                OnPropertyChanged(nameof(ProductRating));
            }
        }

        public string ProductQuantity
        {
            get => Convert.ToString(_productDtoModel.ProductQuantity);
            set
            {
                _productDtoModel.ProductQuantity = Convert.ToInt32(value);
                OnPropertyChanged(nameof(ProductQuantity));
            }
        }

        public string ShopId
        {
            get => Convert.ToString(_productDtoModel.ShopId);
            set
            {
                _productDtoModel.ShopId = Convert.ToInt32(value);
                OnPropertyChanged(nameof(ShopId));
            }
        }
    }
}
