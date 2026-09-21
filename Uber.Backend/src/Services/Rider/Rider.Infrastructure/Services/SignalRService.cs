using BuildingBlocks.Common;
using BuildingBlocks.Events;
using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Models.Ride;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Rider.Application.Common;
using Rider.Application.Data.Services;
using Rider.Domain.Models;
using Rider.Domain.Models.Rider;
using Rider.Infrastructure.SignalREndpoints.Rider;


namespace Rider.Infrastructure.Services;
public class SignalRService(IConnectionManager connectionManager, IHubContext<UpdateRiderLocationHub> hubContext,ILogger<SignalRService> logger) : ISignalRService
{
    public async void SendDriverLocationToRiders(DriverPositionWithRiders driverPositionWithRiders)
    {
        foreach (var item in driverPositionWithRiders.Riders)
        {
            var connectionId = connectionManager.GetConnectionId(item);
            if(connectionId != null)
            {
                try
                {
                   await hubContext.Clients.Client(connectionId).SendAsync("DriverLocationUpdate", 
                       driverPositionWithRiders.UserId,
                       driverPositionWithRiders.Longitude,
                       driverPositionWithRiders.Latitude,
                       driverPositionWithRiders.VehicleType
                    );
                }
                catch(Exception e)
                {
                    logger.LogError(e.ToString());
                }
            }
        }
    }

    public async void NotifyRiderRideAccepted(NotifyRiderRideAcceptedEvent ride)
    {
        var connectionId = connectionManager.GetConnectionId(ride.RiderId);
        if (connectionId != null)
        {
            try
            {
                await hubContext.Clients.Client(connectionId).SendAsync("RideAccepted", 
                    ride.RiderId,
                    ride.DriverId,
                    ride.RideId,
                    ride.Latitude,
                    ride.Longitude
                    );
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }
    }

    public async void SendTripLocationToRiders(ContinuousTripUpdates tripLocation)
    {
        var connectionId = connectionManager.GetConnectionId(tripLocation.RiderId);
        if (connectionId != null)
        {
            try
            {
                await hubContext.Clients.Client(connectionId).SendAsync(SignalRMethods.TRIP_UPDATES,
                    tripLocation.RideId,
                    tripLocation.DriverId,
                    tripLocation.Latitude,
                    tripLocation.Longitude,
                    tripLocation.Time,
                    tripLocation.Distance
                );
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }
    }

    public async void NotifyRiderDriverReached(ReachedPickUpSpotEvent ride)
    {
        var connectionId = connectionManager.GetConnectionId(ride.RiderId);
        if (connectionId != null)
        {
            try
            {
                await hubContext.Clients.Client(connectionId).SendAsync(SignalRMethods.NOTIFY_RIDER_DRIVER_REACHED_PICKUP_SPOT,
                    ride.RiderId,
                    ride.DriverId,
                    ride.RideId,
                    ride.Reached
                    );
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }
    }

    public async void NotidyRiderDriverReachedDropOff(ReachedDropOffSpotEvent spot)
    {
        var connectionId = connectionManager.GetConnectionId(spot.RiderId);
        if (connectionId != null)
        {
            try
            {
                await hubContext.Clients.Client(connectionId).SendAsync(SignalRMethods.NOTIFY_RIDER_DRIVER_REACHED_DROPOFF_SPOT,
                spot.RiderId,
                spot.DriverId,
                spot.RideId,
                spot.Reached
                );
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }
    }

    public async void NotifyRiderTripStarted(TripStartedEvent spot)
    {
        var connectionId = connectionManager.GetConnectionId(spot.RiderId);
        if(connectionId != null)
        {
            try
            {
                await hubContext.Clients.Client(connectionId).SendAsync(SignalRMethods.NOTIFY_RIDER_TRIP_STARTED,
                spot.RiderId,
                spot.DriverId,
                spot.RideId
                );
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }
    }
}
