using BuildingBlocks.Dtos;
using BuildingBlocks.Models.Ride;
using BuildingBlocks.Models.Shared;
using Driver.Application.ConnectionManager;
using Driver.Application.Driver.Commands.UpdateDriverLocation;
using Driver.Application.Ride.Commands.AcceptRide;
using Driver.Application.Ride.Commands.SendContinuousTripLocation;
using Driver.Application.Trip.ReachedDropOffSpot;
using Driver.Application.Trip.ReachedPickUpSpot;
using Driver.Application.Trip.StartedTrip;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Driver.API.SignalREndpoints.Driver;

public class UpdateDriverLocationHub(ISender sender, ILogger<UpdateDriverLocationHub> logger, IConnectionManager connectionManager) :Hub
{
    public async Task UpdateLocation(UpdateLocationDto locationDto)
    {
        await sender.Send(new UpdateDriverLocationCommand(locationDto));    
    }

    public async Task AcceptRide(AcceptRideRequest ride)
    {
        await sender.Send(new AcceptRideCommand(ride));
    }

    public async Task SendTripLocationUpdates(ContinuousTripUpdates trip)
    {
        await sender.Send(new SendContinuousRideLocationCommand(trip));
    }

    public async Task ReachedRider(ReachedPickUpSpotModel reached)
    {
        await sender.Send(new ReachedPickUpSpotCommand(reached));
    }

    public async Task StartTrip(TripStarted tripStarted)
    {
        await sender.Send(new StartedTripCommand(tripStarted));
    }

    public async Task ReachedDropOff(ReachedDropOffSpotModel reached)
    {
        await sender.Send(new ReachedDropOffSpotCommand(reached));
    }

    public override Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var connectionId = Context.ConnectionId;
        var userId = httpContext?.Request.Query["riderId"].ToString();
        if (Guid.TryParse(userId, out var riderId))
        {
            connectionManager.AddConnection(riderId, connectionId);
        }
        else
        {
            logger.LogError("Invalid riderId: {riderId}", userId);
        }

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;
        connectionManager.RemoveConnection(connectionId);
        return base.OnDisconnectedAsync(exception);
    }
}
