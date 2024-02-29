using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class CartItemModel
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public int CartItemQuantity { get; set; }

        [ForeignKey("CartId")]
        public int CartId { get; set; }
        public CartModel? Cart { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }
    }
}
