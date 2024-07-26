using Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery : IRequest<GetCarByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarByIdQuery(int id)
        {
            Id = id;
        }
    }
}
