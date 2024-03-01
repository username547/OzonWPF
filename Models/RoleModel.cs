using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;

        public ICollection<UserModel>? Users { get; set; }
    }
}
