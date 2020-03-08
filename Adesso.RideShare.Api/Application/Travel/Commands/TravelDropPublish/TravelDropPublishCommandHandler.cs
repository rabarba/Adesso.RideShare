using Adesso.RideShare.Business.Factories;
using Adesso.RideShare.Business.Services.Impl.Travel.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelDropPublish
{
    public class TravelDropPublishCommandHandler : IRequestHandler<TravelDropPublishCommand, TravelDropPublishDto>
    {
        private readonly ITravelServiceFactory _travelServiceFactory;

        public TravelDropPublishCommandHandler(ITravelServiceFactory travelServiceFactory)
        {
            _travelServiceFactory = travelServiceFactory;
        }
        public async Task<TravelDropPublishDto> Handle(TravelDropPublishCommand request, CancellationToken cancellationToken)
        {
            var travelService = _travelServiceFactory.Create();
            var response = await travelService.DropPublishTravel(new DropPublishTravelRequest
            {
                Id = request.Id
            });

            return new TravelDropPublishDto
            {
                Id = response.Id,
                Message = response.Message
            };
        }
    }
}
