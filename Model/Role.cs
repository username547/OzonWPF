using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role name not specified")]
        [StringLength(50, ErrorMessage = "Role name is too long")]
        public string RoleName { get; set; } = string.Empty;

        public ICollection<User>? Users { get; set; }
    }
}
