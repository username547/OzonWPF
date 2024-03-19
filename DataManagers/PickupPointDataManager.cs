using Microsoft.EntityFrameworkCore;
using Ozon.Data;
using Ozon.Model;
using Ozon.Models.QueryDTO;
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

        public static List<PickupPointStatsDto> GetAllPickupPointsWithStats()
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
        }
    }
}
