using Ozon.Commands;
using Ozon.DataManage;
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
    public class AdminViewModel : ViewModelBase
    {
        private ObservableCollection<UserModel> _allUsers;
        private ObservableCollection<SellerModel> _allSellers;
        private ObservableCollection<ShopModel> _allShops;
        private ObservableCollection<ProductModel> _allProducts;
        public Window currentWindow;
        private ProductModel _selectedProduct;
        
        /*Commands for Products*/
        public ICommand NavigateToCreateProductWindow { get; }
        public ICommand NavigateToUpdateProductWindow { get; }
        public ICommand DeleteProduct { get; }
        public ICommand RefreshProducts { get; }

        /*Commands for PickupPoints*/
        public ICommand NavigateToStatisticsWindow { get; }

        public AdminViewModel(Window currentWindow)
        {
            this.currentWindow = currentWindow;
            _allUsers = new ObservableCollection<UserModel>(UserDataManager.GetAllUsers());
            _allSellers = new ObservableCollection<SellerModel>(SellerDataManager.GetAllSellers());
            _allShops = new ObservableCollection<ShopModel>(ShopDataManager.GetAllShops());
            _allProducts = new ObservableCollection<ProductModel>(ProductDataManager.GetAllProducts());
            NavigateToCreateProductWindow = new RelayCommand(parameter =>
            {
                CreateProductWindow createProductWindow = new CreateProductWindow();
                createProductWindow.Show();
            });
            NavigateToUpdateProductWindow = new RelayCommand(parameter =>
            {
                if (SelectedProduct != null)
                {
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
                else
                {
                    MessageBox.Show("Please select a product to update.");
                }
            });
            DeleteProduct = new RelayCommand(parameter =>
            {
                if (SelectedProduct != null) ProductDataManager.DeleteProduct(SelectedProduct.ProductId);
                else MessageBox.Show("Please select a product to update.");
            });
            RefreshProducts = new RelayCommand(parameter =>
            {
                AllProducts.Clear();
                var updatedProducts = ProductDataManager.GetAllProducts();
                foreach (var product in updatedProducts) AllProducts.Add(product);
            });
            NavigateToStatisticsWindow = new RelayCommand(parameter =>
            {
                StatisticsWindow statisticsWindow = new StatisticsWindow();
                statisticsWindow.Show();
            });
        }

        public ObservableCollection<UserModel> AllUsers
        {
            get { return _allUsers; }
            set
            {
                _allUsers = value;
                OnPropertyChanged(nameof(AllUsers));
            }
        }
        public ObservableCollection<SellerModel> AllSellers
        {
            get { return _allSellers; }
            set
            {
                _allSellers = value;
                OnPropertyChanged(nameof(AllSellers));
            }
        }

        public ObservableCollection<ShopModel> AllShops
        {
            get { return _allShops; }
            set
            {
                _allShops = value;
                OnPropertyChanged(nameof(AllShops));
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
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
    }
}
