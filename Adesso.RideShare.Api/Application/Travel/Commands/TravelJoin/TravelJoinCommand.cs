using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelJoin
{
    public class TravelJoinCommand : IRequest<TravelJoinDto>
    {
        [Required] public string Id { get; set; }
        [Range(1, 3)] public int SeatingCount { get; set; } = 1;
    }
}
