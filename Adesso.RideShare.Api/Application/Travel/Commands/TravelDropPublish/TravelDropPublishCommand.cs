using MediatR;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelDropPublish
{
    public class TravelDropPublishCommand : IRequest<TravelDropPublishDto>
    {
        public string Id { get; set; }
    }
}
