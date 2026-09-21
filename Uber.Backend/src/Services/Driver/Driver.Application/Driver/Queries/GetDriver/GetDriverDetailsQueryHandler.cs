using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Application.Services;
using Mapster;

namespace Driver.Application.Driver.Queries.GetDriver;
public class GetDriverDetailsQueryHandler(IDriverRepository driverRepository) : IQueryHandler<GetDriverDetailsQuery, GetRiderDetailsResult>
{
    public async Task<GetRiderDetailsResult> Handle(GetDriverDetailsQuery request, CancellationToken cancellationToken)
    {
         var driver = await driverRepository.GetDriverDetails(request.DriverId);
        return driver.Adapt<GetRiderDetailsResult>();
    }
}
