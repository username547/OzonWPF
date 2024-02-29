using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeePassport { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string EmployeePhone { get; set; } = string.Empty;

        [Required]
        public int EmployeeSalary { get; set; }

        [ForeignKey("PickupPointId")]
        public int PickupPointId { get; set; }
        public PickupPoint? PickupPoint { get; set; }
    }
}
