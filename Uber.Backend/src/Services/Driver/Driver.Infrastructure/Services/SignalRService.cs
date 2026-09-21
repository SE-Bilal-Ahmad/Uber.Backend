using Driver.API.SignalREndpoints.Driver;
using Driver.Application.ConnectionManager;
using Driver.Application.Services;
using Driver.Domain.Models.RiderLocation;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Driver.Infrastructure.Services;
public class SignalRService(IConnectionManager connectionManager, IHubContext<UpdateDriverLocationHub> hubContext, ILogger<SignalRService> logger) :ISignalRService
{
    public async void SendRideRequestToDriver(RiderRequestedLocation riderRequestedLocation)
    {
        foreach (var item in riderRequestedLocation.NearbyDrivers)
        {
            var connectionId = connectionManager.GetConnectionId(item);
            if (connectionId != null)
            {
                try
                {
                    await hubContext.Clients.Client(connectionId).SendAsync("SendRideRequestToDrivers",
                        riderRequestedLocation.RiderId,
                        riderRequestedLocation.PickUpLocation.Longitude,
                        riderRequestedLocation.PickUpLocation.Latitude,
                        riderRequestedLocation.DropOffLocation.Longitude,
                        riderRequestedLocation.DropOffLocation.Latitude,
                        riderRequestedLocation.RideId
                     );
                }
                catch (Exception e)
                {
                    logger.LogError(e.ToString());
                }
            }
        }
    }

    public void SendTripStartedStatus(TripStarted tripStarted)
    {
        throw new NotImplementedException();
    }
}
