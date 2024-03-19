using Microsoft.EntityFrameworkCore;
using Ozon.Data;
using Ozon.Models.QueryDTO;
using System.Windows;

namespace Ozon.DataManagers
{
    public class EmployeeDataManager
    {
        public static List<EmployeeStatsDto> GetAllEmployeesWithStats(int pickupPointId)
        {
            using ApplicationDbContext _context = new();

            var query = from e in _context.Employees
                        join u in _context.Users on e.UserId equals u.UserId
                        join i in _context.Issuances on e.EmployeeId equals i.EmployeeId into issuanceGroup
                        from i in issuanceGroup.DefaultIfEmpty()
                        where e.PickupPointId == pickupPointId
                        group new { e, u, i } by new { e.EmployeeId, u.UserName, u.UserSurname } into g
                        select new EmployeeStatsDto
                        {
                            EmployeeId = g.Key.EmployeeId,
                            UserName = g.Key.UserName,
                            UserSurname = g.Key.UserSurname,
                            IssuanceCount = g.Count(x => x.i != null),
                            AverageRating = g.Where(x => x.i != null).Average(x => x.i.IssuanceRating)
                        };

            return query.ToList();
        }
    }
}
