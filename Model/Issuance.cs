using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon.Model
{
    public class Issuance
    {
        [Key]
        public int IssuanceId { get; set; }

        [Required]
        public DateTime IssuanceDate { get; set; }

        [Required]
        public int IssuanceRating { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
