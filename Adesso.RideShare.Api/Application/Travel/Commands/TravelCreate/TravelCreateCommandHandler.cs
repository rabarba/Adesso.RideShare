using Adesso.RideShare.Business.Factories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Adesso.RideShare.Business.Services.Impl.Travel.Requests;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelCreate
{
    public class TravelCreateCommandHandler : IRequestHandler<TravelCreateCommand, TravelCreateDto>
    {
        private readonly ITravelServiceFactory _travelServiceFactory;

        public TravelCreateCommandHandler(ITravelServiceFactory travelServiceFactory)
        {
            _travelServiceFactory = travelServiceFactory;
        }
        public async Task<TravelCreateDto> Handle(TravelCreateCommand request, CancellationToken cancellationToken)
        {
            var travelService = _travelServiceFactory.Create();
            var response = await travelService.CreateTravel(new CreateTravelRequest
            {
                ToFrom = request.ToFrom,
                ToWhere = request.ToWhere,
                Date = request.Date,
                Description = request.Description,
                AvailableSeatingCapacity = request.AvailableSeatingCapacity
            });

            return new TravelCreateDto {
                Id = response.Id
            };
        }
    }
}