using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Models.Ride;
using Rider.Domain.Models;

namespace Rider.Application.Data.Services;
public interface ISignalRService
{
    void SendDriverLocationToRiders(DriverPositionWithRiders driverPositionWithRiders);
    void NotifyRiderRideAccepted(NotifyRiderRideAcceptedEvent ride);
    void SendTripLocationToRiders(ContinuousTripUpdates tripLocation);
    void NotifyRiderDriverReached(ReachedPickUpSpotEvent spot);
    void NotidyRiderDriverReachedDropOff(ReachedDropOffSpotEvent spot);
    void NotifyRiderTripStarted(TripStartedEvent riderId);
}
