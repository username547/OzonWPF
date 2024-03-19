using Ozon.Commands;
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
    public class ProductsViewModel: ViewModelBase
    {
        private ObservableCollection<ProductModel> _allProducts;
        private ProductModel? _selectedProduct = null;
        private string _searchString = string.Empty;
        public string SelectedSortOption { get; set; } = "Name";
        public ICommand NavigateToCreateProductWindow { get; }
        public ICommand NavigateToUpdateProductWindow { get; }
        public ICommand DeleteProduct { get; }
        public ICommand RefreshProducts { get; }

        public ProductsViewModel()
        {
            _allProducts = new ObservableCollection<ProductModel>(ProductDataManager.GetAllProducts());
            NavigateToCreateProductWindow = new RelayCommand(parameter =>
                NavigateToCreateProductWindowExecute());
            NavigateToUpdateProductWindow = new RelayCommand(parameter =>
                NavigateToUpdateProductWindowExecute());
            DeleteProduct = new RelayCommand(parameter =>
                DeleteProductExecute());
            RefreshProducts = new RelayCommand(parameter =>
                RefreshProductsExecute());
        }

        private void NavigateToCreateProductWindowExecute()
        {
            CreateProductWindow createProductWindow = new CreateProductWindow();
            createProductWindow.Show();
        }

        private void NavigateToUpdateProductWindowExecute()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }
            ProductDtoModel productDtoModel = new ProductDtoModel
            {
                ProductName = SelectedProduct.ProductName,
                ProductDescription = SelectedProduct.ProductDescription,
                ProductPrice = SelectedProduct.ProductPrice,
                ProductRating = SelectedProduct.ProductRating,
                ProductQuantity = SelectedProduct.ProductQuantity,
                ShopId = SelectedProduct.ShopId,
            };
            UpdateProductWindow updateProductWindow = new UpdateProductWindow(SelectedProduct.ProductId, productDtoModel);
            updateProductWindow.Show();
        }

        private void DeleteProductExecute()
        {
            if (SelectedProduct != null) ProductDataManager.DeleteProduct(SelectedProduct.ProductId);
            else MessageBox.Show("Please select a product to update.");
        }

        /*private void RefreshProductsExecute()
        {
            AllProducts.Clear();
            var updatedProducts = ProductDataManager.GetAllProducts();
            foreach (var product in updatedProducts) AllProducts.Add(product);
        }*/

        private void RefreshProductsExecute()
        {
            AllProducts.Clear();
            var allProducts = ProductDataManager.GetAllProducts();
            foreach (var product in allProducts)
            {
                if (string.IsNullOrWhiteSpace(_searchString) ||
                    product.ProductName.Contains(_searchString))
                {
                    AllProducts.Add(product);
                }
            }
        }

        public ObservableCollection<ProductModel> AllProducts
        {
            get { return _allProducts; }
            set
            {
                _allProducts = value;
                OnPropertyChanged(nameof(AllProducts));
            }
        }

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct!; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                RefreshProductsExecute(); // При изменении строки поиска обновляем список продуктов
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
