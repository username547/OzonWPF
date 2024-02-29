using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon.Model
{
    public class ShopModel
    {
        [Key]
        public int ShopId { get; set; }

        [Required]
        [StringLength(50)]
        public string ShopName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string ShopDescription { get; set; } = string.Empty;

        [Required]
        public int ShopRating { get; set; }

        [ForeignKey("SellerId")]
        public int SellerId { get; set; }
        public SellerModel? Seller { get; set; }
    }
}
