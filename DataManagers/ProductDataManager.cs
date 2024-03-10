using Microsoft.VisualBasic.ApplicationServices;
using Ozon.Data;
using Ozon.Model;
using Ozon.Models.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Ozon.DataManagers
{
    public class ProductDataManager
    {
        public static List<ProductModel> GetAllProducts()
        {
            using ApplicationDbContext context = new();
            return context.Products.ToList();
        }

        public static void CreateProduct(ProductDtoModel dto)
        {
            using ApplicationDbContext context = new();
            ProductModel newProduct = new ProductModel
            {
                ProductName = dto.ProductName,
                ProductDescription = dto.ProductDescription,
                ProductPrice = dto.ProductPrice,
                ProductRating = dto.ProductRating,
                ProductQuantity = dto.ProductQuantity,
                ShopId = dto.ShopId,
            };

            context.Products.Add(newProduct);
            context.SaveChanges();
        }

        public static bool UpdateProduct(int productId, ProductDtoModel dto)
        {
            using ApplicationDbContext context = new();
            var product = context.Products.FirstOrDefault(x => x.ProductId == productId);

            if (product == null) return false;

            product.ProductName = dto.ProductName;
            product.ProductDescription = dto.ProductDescription;
            product.ProductPrice = dto.ProductPrice;
            product.ProductRating = dto.ProductRating;
            product.ProductQuantity = dto.ProductQuantity;
            product.ShopId = dto.ShopId;

            context.SaveChanges();

            return true;
        }

        public static bool DeleteProduct(int productId)
        {
            using ApplicationDbContext context = new();
            var product = context.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product == null) return false;

            context.Products.Remove(product);
            context.SaveChanges();

            return true;
        }
    }
}
