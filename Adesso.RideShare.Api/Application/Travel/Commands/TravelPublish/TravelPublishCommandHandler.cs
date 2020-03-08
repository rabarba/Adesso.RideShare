using Adesso.RideShare.Business.Factories;
using Adesso.RideShare.Business.Services.Impl.Travel.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelPublish
{
    public class TravelPublishCommandHandler : IRequestHandler<TravelPublishCommand, TravelPublishDto>
    {
        private readonly ITravelServiceFactory _travelServiceFactory;

        public TravelPublishCommandHandler(ITravelServiceFactory travelServiceFactory)
        {
            _travelServiceFactory = travelServiceFactory;
        }
        public async Task<TravelPublishDto> Handle(TravelPublishCommand request, CancellationToken cancellationToken)
        {
            var travelService = _travelServiceFactory.Create();
            var response = await travelService.PublishTravel(new PublishTravelRequest
            {
                Id = request.Id
            });

            return new TravelPublishDto
            {
                Id = response.Id,
                Message = response.Message
            };
        }
    }
}
