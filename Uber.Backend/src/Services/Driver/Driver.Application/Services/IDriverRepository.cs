using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.Driver;
using DriverModel = Driver.Domain.Models.Driver.Driver;

namespace Driver.Application.Services;
public interface IDriverRepository
{
    public Task CreateDriver(CreateDriverEvent driver,CancellationToken cancellationToken);
    public Task<DriverModel> GetDriverDetails(Guid driverId);
}
