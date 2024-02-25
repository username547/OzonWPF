using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string UserPasswordHash { get; set; } = string.Empty;

        [ForeignKey("RoleId")]
        public int? RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
