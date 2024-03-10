using Ozon.Data;
using Ozon.Model;

namespace Ozon.DataManagers
{
    public class ShopDataManager
    {
        public static List<ShopModel> GetAllShops()
        {
            using ApplicationDbContext context = new();
            return context.Shops.ToList();
        }
    }
}
