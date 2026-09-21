using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Mapster;
using Rider.Application.Repository;

namespace Rider.Application.Rider.Queries.GetRiderDetails;
public class GetRiderDetailsQueryHandler(IRiderRepository riderRepository) : IQueryHandler<GetRiderDetailsQuery, GetRiderDetailsResult>
{
    public async Task<GetRiderDetailsResult> Handle(GetRiderDetailsQuery request, CancellationToken cancellationToken)
    {
        var rider = await riderRepository.GetRiderDetails(request.RiderId);
        return rider.Adapt<GetRiderDetailsResult>();
    }
}
