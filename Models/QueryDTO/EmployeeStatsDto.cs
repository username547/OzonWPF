namespace Ozon.Models.QueryDTO
{
    public class EmployeeStatsDto
    {
        public int EmployeeId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserSurname { get; set; } = string.Empty;
        public int IssuanceCount { get; set; }
        public double AverageRating { get; set; }
    }
}
