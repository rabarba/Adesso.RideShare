using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelPublish
{
    public class TravelPublishCommand : IRequest<TravelPublishDto>
    {
        [Required] public string Id { get; set; }
    }
}
