using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon.Model
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserModel? User { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
    }
}
