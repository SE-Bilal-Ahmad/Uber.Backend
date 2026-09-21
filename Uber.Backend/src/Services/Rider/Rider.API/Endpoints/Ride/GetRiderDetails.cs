using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rider.Application.Rider.Queries.GetRiderDetails;

namespace Rider.API.Endpoints.Ride;

public record GetRiderDetailsResponse(
    string FirstName,
    string LastName,
    string ContactNo,
    string Country
);
public class GetRiderDetails : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/rider/details", async ([FromQuery] Guid riderId, ISender sender) =>
        {
            var result = await sender.Send(new GetRiderDetailsQuery(riderId));
            var response = result.Adapt<GetRiderDetailsResponse>();
            return response;
        });
    }
}
