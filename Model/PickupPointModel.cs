using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class PickupPointModel
    {
        [Key]
        public int PickupPointId { get; set; }

        [Required]
        [StringLength(100)]
        public string PickupPointAddress { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string PickupPointDescription { get; set; } = string.Empty;

        [Required]
        public int PickupPointRating { get; set; }

        public ICollection<EmployeeModel>? Employees { get; set; }
    }
}
