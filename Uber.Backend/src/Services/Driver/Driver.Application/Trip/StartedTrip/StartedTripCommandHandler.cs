using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using MediatR;

namespace Driver.Application.Trip.StartedTrip;
public class StartedTripCommandHandler(IPublishEndpoint publish) : ICommandHandler<StartedTripCommand, Unit>
{
    public async Task<Unit> Handle(StartedTripCommand request, CancellationToken cancellationToken)
    {
        await publish.Publish(request.TripStarted.Adapt<TripStartedEvent>());
        return Unit.Value;
    }
}
