namespace Adesso.RideShare.Business.Services.Impl.Travel.Requests
{
    public class JoinTravelRequest
    {
        public string Id { get; set; }
        public int SeatingCount { get; set; } = 1;
    }
}
