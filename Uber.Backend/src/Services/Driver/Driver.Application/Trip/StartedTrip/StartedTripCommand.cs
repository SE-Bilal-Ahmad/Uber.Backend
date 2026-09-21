using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Driver.Application.Trip.StartedTrip;
public record StartedTripCommand(TripStarted TripStarted):ICommand<Unit>;
