using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon.Model
{
    public class PickupPoint
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

        public ICollection<Employee>? Employees { get; set; }
    }
}
