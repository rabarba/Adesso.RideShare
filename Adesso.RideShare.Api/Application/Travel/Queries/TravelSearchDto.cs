using System;

namespace Adesso.RideShare.Api.Application.Travel.Queries
{
    public class TravelSearchDto
    {
        public string Id { get; set; }
        public int ToFrom { get; set; }
        public int ToWhere { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AvailableSeatingCapacity { get; set; }
    }
}
