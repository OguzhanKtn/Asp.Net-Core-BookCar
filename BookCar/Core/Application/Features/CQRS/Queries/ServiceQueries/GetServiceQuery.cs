using Application.Features.CQRS.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.ServiceQueries
{
    public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
    {
    }
}
