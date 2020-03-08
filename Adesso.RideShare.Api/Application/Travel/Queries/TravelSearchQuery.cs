using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Adesso.RideShare.Api.Application.Travel.Queries
{
    public class TravelSearchQuery : IRequest<List<TravelSearchDto>>
    {
        [Required] [Range(1, 1000)] public int ToFrom { get; set; }
        [Required] [Range(1, 1000)] public int ToWhere { get; set; }
    }
}
