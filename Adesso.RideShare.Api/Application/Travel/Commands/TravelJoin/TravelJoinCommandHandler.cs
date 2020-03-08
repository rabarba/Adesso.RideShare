using Adesso.RideShare.Api.Application.Travel.Queries;
using Adesso.RideShare.Business.Factories;
using Adesso.RideShare.Business.Services.Impl.Travel.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelJoin
{
    public class TravelJoinCommandHandler : IRequestHandler<TravelJoinCommand, TravelJoinDto>
    {
        private readonly ITravelServiceFactory _travelServiceFactory;

        public TravelJoinCommandHandler(ITravelServiceFactory travelServiceFactory)
        {
            _travelServiceFactory = travelServiceFactory;
        }
        public async Task<TravelJoinDto> Handle(TravelJoinCommand request, CancellationToken cancellationToken)
        {
            var travelService = _travelServiceFactory.Create();
            var response = await travelService.JoinTravel(new JoinTravelRequest
            {
                Id = request.Id,
                SeatingCount = request.SeatingCount
            });

            return new TravelJoinDto
            {
                Id = response.Id,
                Message = response.Message
            };
        }
    }
}
