namespace Ozon.Models.DTO
{
    public class ProductDtoModel
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int ProductPrice { get; set; }
        public int ProductRating { get; set; }
        public int ProductQuantity { get; set; }
        public int ShopId { get; set; }
    }
}
