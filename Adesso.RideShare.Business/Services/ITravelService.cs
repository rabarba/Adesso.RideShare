using Adesso.RideShare.Business.Services.Impl.Travel.Requests;
using Adesso.RideShare.Business.Services.Impl.Travel.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adesso.RideShare.Business.Services
{
    public interface ITravelService
    {
        Task<CreateTravelResponse> CreateTravel(CreateTravelRequest request);

        Task<PublishTravelResponse> PublishTravel(PublishTravelRequest request);

        Task<DropPublishTravelResponse> DropPublishTravel(DropPublishTravelRequest request);

        Task<JoinTravelResponse> JoinTravel(JoinTravelRequest request);

        Task<List<TravelResponse>> GetTravelList(GetTravelRequest request);
    }
}
