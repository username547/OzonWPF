using Ozon.Data;
using Ozon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon.DataManagers
{
    public class PickupPointDataManager
    {
        public static List<PickupPointModel> GetAllPickupPoints()
        {
            using ApplicationDbContext context = new();
            return context.PickupPoints.ToList();
        }
    }
}
