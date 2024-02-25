using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon.Model
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }

        [Required]
        [StringLength(50)]
        public string ShopName = string.Empty;

        [Required]
        [StringLength(100)]
        public string ShopDescription = string.Empty;

        [ForeignKey("SellerId")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }
    }
}
