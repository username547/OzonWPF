using Ozon.Commands;
using Ozon.DataManagers;
using Ozon.Model;
using Ozon.Models.DTO;
using Ozon.Patterns;
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

        private Visibility _productsTabVisibility = Visibility.Visible;
        private Visibility _productControlButtonsVisibility = Visibility.Visible;
        private Visibility _productCreateButtonVisibility = Visibility.Visible;
        private Visibility _productUpdateButtonVisibility = Visibility.Visible;
        private Visibility _productDeleteButtonVisibility = Visibility.Visible;

        public ProductsViewModel()
        {
            _allProducts = new ObservableCollection<ProductModel>(ProductDataManager.GetAllProducts());
            NavigateToCreateProductWindow = new RelayCommand(parameter =>
                NavigateToCreateProductWindowExecute());
            NavigateToUpdateProductWindow = new RelayCommand(parameter =>
                NavigateToUpdateProductWindowExecute());
            DeleteProduct = new RelayCommand(parameter =>
                DeleteProductExecute());

            switch (Singleton.Instance.Role)
            {
                case "Admin":
                    break;
                case "Employee":
                    _productCreateButtonVisibility = Visibility.Collapsed;
                    _productDeleteButtonVisibility= Visibility.Collapsed;
                    break;
                case "Seller":
                    break;
                case "User":
                    _productControlButtonsVisibility = Visibility.Collapsed;
                    break;
                default:
                    _productsTabVisibility = Visibility.Collapsed;
                    _productControlButtonsVisibility = Visibility.Collapsed;
                    break;
            }

            ProductDataManager.ProductCreated += (sender, e) => RefreshProducts();
            ProductDataManager.ProductUpdated += (sender, e) => RefreshProducts();
            ProductDataManager.ProductDeleted += (sender, e) => RefreshProducts();
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

        public void RefreshProducts()
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

        public Visibility ProductsTabVisibility
        {
            get { return _productsTabVisibility; }
            set
            {
                _productsTabVisibility = value;
                OnPropertyChanged(nameof(ProductsTabVisibility));
            }
        }

        public Visibility ProductControlButtonsVisibility
        {
            get { return _productControlButtonsVisibility; }
            set
            {
                _productControlButtonsVisibility = value;
                OnPropertyChanged(nameof(ProductControlButtonsVisibility));
            }
        }

        public Visibility ProductCreateButtonVisibility
        {
            get { return _productCreateButtonVisibility; }
            set
            {
                _productCreateButtonVisibility = value;
                OnPropertyChanged(nameof(ProductCreateButtonVisibility));
            }
        }

        public Visibility ProductUpdateButtonVisibility
        {
            get { return _productUpdateButtonVisibility; }
            set
            {
                _productUpdateButtonVisibility = value;
                OnPropertyChanged(nameof(ProductUpdateButtonVisibility));
            }
        }

        public Visibility ProductDeleteButtonVisibility
        {
            get { return _productDeleteButtonVisibility; }
            set
            {
                _productDeleteButtonVisibility = value;
                OnPropertyChanged(nameof(ProductDeleteButtonVisibility));
            }
        }
    }
}
