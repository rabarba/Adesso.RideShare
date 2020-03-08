using Adesso.RideShare.Business.Factories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.RideShare.Api.Application.Travel.Queries
{
    public class TravelSearchQueryHandler : IRequestHandler<TravelSearchQuery, List<TravelSearchDto>>
    {
        private readonly ITravelServiceFactory _travelServiceFactory;

        public TravelSearchQueryHandler(ITravelServiceFactory travelServiceFactory)
        {
            _travelServiceFactory = travelServiceFactory;
        }
        public async Task<List<TravelSearchDto>> Handle(TravelSearchQuery request, CancellationToken cancellationToken)
        {
            var travelService = _travelServiceFactory.Create();
            var response = await travelService.GetTravelList(new Business.Services.Impl.Travel.Requests.GetTravelRequest
            {
                ToFrom = request.ToFrom,
                ToWhere = request.ToWhere
            });

            return response.Select(item => new TravelSearchDto
            {
                Id = item.Id,
                ToFrom = item.ToFrom,
                ToWhere = item.ToWhere,
                Description = item.Description,
                Date = item.Date,
                AvailableSeatingCapacity = item.AvailableSeatingCapacity
            }).ToList();
        }
    }
}
