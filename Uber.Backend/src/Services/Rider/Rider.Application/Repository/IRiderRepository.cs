using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.Driver;
using BuildingBlocks.Messaging.Events.Rider;
using RiderModel = Rider.Domain.Models.Rider.Rider;

namespace Rider.Application.Repository;
public interface IRiderRepository
{
    public Task CreateRider(CreateRiderEvent driver, CancellationToken cancellationToken);
    public Task<RiderModel> GetRiderDetails(Guid RiderId);
}
