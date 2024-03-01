using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int OrderPrice { get; set; }

        [Required]
        public int PickupPointId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime OrderExpDate { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserModel? User { get; set; }

        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        public StatusModel? Status { get; set; }

        public ICollection<OrderItemModel>? OrderItems { get; set; }
        public IssuanceModel? Issuance { get; set; }
    }
}
