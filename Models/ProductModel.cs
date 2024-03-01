using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string ProductDescription { get; set; } = string.Empty;

        [Required]
        public int ProductPrice { get; set; }

        [Required]
        public int ProductRating { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [ForeignKey("ShopId")]
        public int ShopId { get; set; }
        public ShopModel? Shop { get; set; }

        public ICollection<CartItemModel>? CartItems { get; set; }
        public ICollection<OrderItemModel>? OrderItems { get; set; }
    }
}
