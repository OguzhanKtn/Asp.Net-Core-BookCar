using Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarWithBrandQuery : IRequest<List<GetCarWithBrandQueryResult>>
    {
    }
}
