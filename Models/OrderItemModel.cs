using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class OrderItemModel
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderItemQuantity { get; set; }

        [Required]
        public int OrderItemRating { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public OrderModel? Order { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }
    }
}
