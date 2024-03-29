using Ozon.Data;
using Ozon.Model;
using Ozon.Models.QueryDTO;

namespace Ozon.DataManagers
{
    public class PickupPointDataManager
    {
        public static List<PickupPointModel> GetAllPickupPoints()
        {
            using ApplicationDbContext context = new();
            return context.PickupPoints.ToList();
        }

        public static List<PickupPointStatsDto> GetAllPickupPointsWithStats(int userId, string userRole)
        {
            using ApplicationDbContext context = new();
            if (userRole == "Admin") return GetAllPickupPointsStats(context);
            else return GetEmployeePickupPointsStats(context, userId);
        }

        private static List<PickupPointStatsDto> GetAllPickupPointsStats(ApplicationDbContext context)
        {
            // Получаем количество сотрудников на каждом пункте выдачи
            var employeeCounts = context.Employees
                .GroupBy(e => e.PickupPointId)
                .ToDictionary(g => g.Key, g => g.Count());

            // Получаем количество выданных заказов на каждом пункте выдачи
            var issuanceCounts = context.Issuances
                .Join(context.Employees, i => i.EmployeeId, e => e.EmployeeId, (i, e) => e.PickupPointId)
                .GroupBy(ppId => ppId)
                .ToDictionary(g => g.Key, g => g.Count());

            // Получаем средний рейтинг на каждом пункте выдачи
            var averageRatings = context.Issuances
                .Join(context.Employees, i => i.EmployeeId, e => e.EmployeeId, (i, e) => new { i.IssuanceRating, e.PickupPointId })
                .GroupBy(x => x.PickupPointId)
                .ToDictionary(g => g.Key, g => g.Average(x => x.IssuanceRating));

            // Создаем список PickupPointStatsDto на основе полученных данных
            var statistics = context.PickupPoints
                .ToList()
                .Select(pp => new PickupPointStatsDto
                {
                    PickupPointId = pp.PickupPointId,
                    PickupPointAddress = pp.PickupPointAddress,
                    PickupPointDescription = pp.PickupPointDescription,
                    EmployeeCount = employeeCounts.ContainsKey(pp.PickupPointId) ? employeeCounts[pp.PickupPointId] : 0,
                    IssuanceCount = issuanceCounts.ContainsKey(pp.PickupPointId) ? issuanceCounts[pp.PickupPointId] : 0,
                    AverageRating = averageRatings.ContainsKey(pp.PickupPointId) ? averageRatings[pp.PickupPointId] : 0
                })
                .ToList();

            return statistics;
        }

        private static List<PickupPointStatsDto> GetEmployeePickupPointsStats(ApplicationDbContext context, int userId)
        {
            // Получаем ID пунктов выдачи, где работает данный сотрудник
            var employeePickupPointIds = context.Employees
                .Where(e => e.UserId == userId)
                .Select(e => e.PickupPointId)
                .ToList();

            // Фильтруем статистику пунктов выдачи, чтобы оставить только те, где работает сотрудник
            var statistics = GetAllPickupPointsStats(context)
                .Where(pp => employeePickupPointIds.Contains(pp.PickupPointId))
                .ToList();

            return statistics;
        }

        /*public static List<PickupPointStatsDto> GetAllPickupPointsWithStats(int userId, string userRole)
        {
            using ApplicationDbContext context = new();

            // Получаем количество сотрудников на каждом пункте выдачи
            var employeeCounts = context.Employees
                .GroupBy(e => e.PickupPointId)
                .ToDictionary(g => g.Key, g => g.Count());

            // Получаем количество выданных заказов на каждом пункте выдачи
            var issuanceCounts = context.Issuances
                .Join(context.Employees, i => i.EmployeeId, e => e.EmployeeId, (i, e) => e.PickupPointId)
                .GroupBy(ppId => ppId)
                .ToDictionary(g => g.Key, g => g.Count());

            // Получаем средний рейтинг на каждом пункте выдачи
            var averageRatings = context.Issuances
                .Join(context.Employees, i => i.EmployeeId, e => e.EmployeeId, (i, e) => new { i.IssuanceRating, e.PickupPointId })
                .GroupBy(x => x.PickupPointId)
                .ToDictionary(g => g.Key, g => g.Average(x => x.IssuanceRating));

            // Создаем список PickupPointStatsDto на основе полученных данных
            var statistics = context.PickupPoints
                .ToList()
                .Select(pp => new PickupPointStatsDto
                {
                    PickupPointId = pp.PickupPointId,
                    PickupPointAddress = pp.PickupPointAddress,
                    PickupPointDescription = pp.PickupPointDescription,
                    EmployeeCount = employeeCounts.ContainsKey(pp.PickupPointId) ? employeeCounts[pp.PickupPointId] : 0,
                    IssuanceCount = issuanceCounts.ContainsKey(pp.PickupPointId) ? issuanceCounts[pp.PickupPointId] : 0,
                    AverageRating = averageRatings.ContainsKey(pp.PickupPointId) ? averageRatings[pp.PickupPointId] : 0
                })
                .ToList();

            return statistics;
        }*/
    }
}
