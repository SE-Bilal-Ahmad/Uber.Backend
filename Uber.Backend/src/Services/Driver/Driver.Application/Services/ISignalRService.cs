using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Domain.Models.RiderLocation;

namespace Driver.Application.Services;
public interface ISignalRService
{
    void SendRideRequestToDriver(RiderRequestedLocation riderRequestedLocation);
    void SendTripStartedStatus(TripStarted tripStarted);
}
