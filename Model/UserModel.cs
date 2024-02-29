using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon.Model
{
    public class UserModel
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
        public RoleModel? Role { get; set; }

        public ICollection<OrderModel>? Orders { get; set; }
        public CartModel? Cart { get; set; }
    }
}
