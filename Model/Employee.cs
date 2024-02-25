using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeePasport { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string EmployeePhone { get; set; } = string.Empty;

        [Required]
        public int EmployeeSalary { get; set; }

        [ForeignKey("PickupPointId")]
        public int PickupPointId { get; set; }
        public PickupPoint? PickupPoint { get; set;}
    }
}
