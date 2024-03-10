using Ozon.Data;
using Ozon.DataManage;
using Ozon.Model;

namespace Ozon.DataManagers
{
    public class SellerDataManager
    {
        public static List<SellerModel> GetAllSellers()
        {
            using ApplicationDbContext context = new();
            return context.Sellers.ToList();
        }

        public static bool CreateSeller(int userId, string sellerPassport, string sellerINN, string sellerPhone)
        {
            using ApplicationDbContext context = new();
            var tempUser = context.Users.FirstOrDefault(x => x.UserId == userId);
            int? roleId = UserDataManager.GetRoleId("Seller");

            if (tempUser == null || roleId == null) return false;

            SellerModel newSeller = new SellerModel
            {
                UserId = userId,
                SellerPassport = sellerPassport,
                SellerINN = sellerINN,
                SellerPhone = sellerPhone
            };

            context.Add(newSeller);
            context.SaveChanges();

            return true;
        }
    }
}
