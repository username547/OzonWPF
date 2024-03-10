using Microsoft.EntityFrameworkCore.Query;
using Ozon.Commands;
using Ozon.DataManagers;
using Ozon.Models.DTO;
using Ozon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ozon.ViewModels
{
    public class UpdateProductViewModel : ViewModelBase
    {
        public Window currentWindow;
        private readonly int _productId;
        private readonly ProductDtoModel _productDtoModel;

        public ICommand UpdateCommand { get; }
        public ICommand CancelCommand { get; }

        public UpdateProductViewModel(Window currentWindow, int productId, ProductDtoModel dto)
        {
            this.currentWindow = currentWindow;
            _productId = productId;
            _productDtoModel = dto;
            UpdateCommand = new RelayCommand(parameter =>
            {
                ProductDataManager.UpdateProduct(_productId, dto);
                currentWindow.Close();
            });
            CancelCommand = new RelayCommand(parameter =>
            {
                currentWindow.Close();
            });
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
