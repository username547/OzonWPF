using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string SellerPassport { get; set; } = string.Empty;

        [Required]
        [StringLength(12)]
        public string SellerINN { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string SellerPhone { get; set; } = string.Empty;
    }
}
