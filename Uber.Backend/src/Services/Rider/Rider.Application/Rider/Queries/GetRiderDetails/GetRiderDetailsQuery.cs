using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;

namespace Rider.Application.Rider.Queries.GetRiderDetails;
public  record GetRiderDetailsQuery(Guid RiderId):IQuery<GetRiderDetailsResult>;
public record GetRiderDetailsResult(
    string FirstName,
    string LastName,
    string Country,
    string ContactNo
);
