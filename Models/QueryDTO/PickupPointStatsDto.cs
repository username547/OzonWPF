namespace Ozon.Models.QueryDTO
{
    public class PickupPointStatsDto
    {
        public int PickupPointId { get; set; }
        public string PickupPointAddress { get; set; } = string.Empty;
        public string PickupPointDescription { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
        public int IssuanceCount { get; set; }
        public double AverageRating { get; set; }
    }
}
