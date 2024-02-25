using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusName { get; set; } = string.Empty;

        public ICollection<Order>? Orders { get; set; }
    }
}
