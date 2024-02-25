using System.ComponentModel.DataAnnotations.Schema;
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
        public string SellerPasport { get; set; } = string.Empty;

        [Required]
        [StringLength(12)]
        public string SellerINN = string.Empty;

        [Required]
        [StringLength(10)]
        public string SellerPhone = string.Empty;

        [Required]
        public int SellerRating { get; set; }
    }
}
