using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string UserSurname { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; } = string.Empty;

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public Cart? Cart { get; set; }
    }
}
