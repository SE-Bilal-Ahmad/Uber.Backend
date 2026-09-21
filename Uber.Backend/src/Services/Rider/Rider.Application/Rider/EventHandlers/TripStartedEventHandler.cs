using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using Rider.Application.Data.Services;

namespace Rider.Application.Rider.EventHandlers
{
    public class TripStartedEventHandler(ISignalRService signalRService) : IConsumer<TripStartedEvent>
    {
        public Task Consume(ConsumeContext<TripStartedEvent> context)
        {
            signalRService.NotifyRiderTripStarted(context.Message);
            return Task.CompletedTask;
        }
    }
}
