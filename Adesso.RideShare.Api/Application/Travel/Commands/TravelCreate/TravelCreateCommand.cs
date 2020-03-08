using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelCreate
{
    public class TravelCreateCommand : IRequest<TravelCreateDto>
    {
        [Required] [Range(1, 1000)] public int ToFrom { get; set; }
        [Required] [Range(1, 1000)] public int ToWhere { get; set; }
        [Required] public DateTime Date { get; set; } = DateTime.Now;
        [Required] public string Description { get; set; }
        [Range(1, 10)] public int AvailableSeatingCapacity { get; set; } = 1;
    }
}
