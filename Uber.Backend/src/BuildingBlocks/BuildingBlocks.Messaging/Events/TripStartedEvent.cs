using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events
{
    public record TripStartedEvent(
    Guid RiderId,
    Guid RideId,
    Guid DriverId
    );
}
