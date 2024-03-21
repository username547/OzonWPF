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
    public enum SortOption
    {
        None,
        NameAscending,
        NameDescending
    }

    public class ProductsViewModel: ViewModelBase
    {
        private ObservableCollection<ProductModel> _allProducts;
        private ProductModel? _selectedProduct = null;
        private string _searchString = string.Empty;
        private SortOption _selectedSortOption = SortOption.None;

        public ICommand NavigateToCreateProductWindow { get; }
        public ICommand NavigateToUpdateProductWindow { get; }
        public ICommand DeleteProduct { get; }

        public ProductsViewModel()
        {
            _allProducts = new ObservableCollection<ProductModel>(ProductDataManager.GetAllProducts());
            NavigateToCreateProductWindow = new RelayCommand(parameter =>
                NavigateToCreateProductWindowExecute());
            NavigateToUpdateProductWindow = new RelayCommand(parameter =>
                NavigateToUpdateProductWindowExecute());
            DeleteProduct = new RelayCommand(parameter =>
                DeleteProductExecute());
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

        private void RefreshProducts()
        {
            AllProducts.Clear();

            var allProducts = ProductDataManager.GetAllProducts();
            var filteredProducts = allProducts.Where(p => string.IsNullOrWhiteSpace(_searchString) || p.ProductName.ToLower().Contains(_searchString.ToLower()));

            switch (SelectedSortOption)
            {
                case SortOption.None:
                    break;
                case SortOption.NameAscending:
                    filteredProducts = filteredProducts.OrderBy(p => p.ProductName);
                    break;
                case SortOption.NameDescending:
                    filteredProducts = filteredProducts.OrderByDescending(p => p.ProductName);
                    break;
            }

            foreach (var product in filteredProducts) _allProducts.Add(product);
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
                RefreshProducts();
                OnPropertyChanged(nameof(SearchString));
            }
        }

        public SortOption SelectedSortOption
        {
            get => _selectedSortOption;
            set
            {
                if (_selectedSortOption != value)
                {
                    _selectedSortOption = value;
                    RefreshProducts();
                }
            }
        }
    }
}
