using Carter;
using Driver.Application.Driver.Queries.GetDriver;
using Mapster;
using MediatR;

namespace Driver.API.Endpoints.Driver;

public record GetVehicleDetailsResponse(
    string FirstName,
    string LastName,
    string ContactNo,
    string Country
  );
public class GetDriverDetails : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/driver/details", async ([FromQuery] Guid driverId, ISender sender) =>
        {
            var result = await sender.Send(new GetDriverDetailsQuery(driverId));
            var response = result.Adapt<GetVehicleDetailsResponse>();
            return response;
        });
    }
}
