using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Application.Driver.Queries.GetDriver;

public record GetDriverDetailsQuery(Guid DriverId):IQuery<GetRiderDetailsResult>;
public record GetRiderDetailsResult(
    string FirstName, 
    string LastName,
    string ContactNo,
    string Country
);

