using Application.Features.CQRS.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {
    }
}
