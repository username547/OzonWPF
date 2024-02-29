using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class IssuanceModel
    {
        [Key]
        public int IssuanceId { get; set; }

        [Required]
        public DateTime IssuanceDate { get; set; }

        [Required]
        public int IssuanceRating { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public OrderModel? Order { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public EmployeeModel? Employee { get; set; }
    }
}
