using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int OrderPrice { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime OrderExpDate { get; set; }

        [Required]
        public int PickupPointId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        public Status? Status { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
        public Issuance? Issuance { get; set; }
    }
}
