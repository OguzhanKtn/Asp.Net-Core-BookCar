using Application.Features.CQRS.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.StatisticsQueries
{
    public class GetCarCountByKmSmallerThan1000Query : IRequest<GetCarCountByKmSmallerThan1000QueryResult>
    {
    }
}
