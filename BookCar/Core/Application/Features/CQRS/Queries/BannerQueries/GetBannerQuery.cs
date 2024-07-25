using Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace Application.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerQuery : IRequest<List<GetBannerQueryResult>>
    {
    }
}
