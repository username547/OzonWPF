using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon.Model
{
    public class Product
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
        public Shop? Shop { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
