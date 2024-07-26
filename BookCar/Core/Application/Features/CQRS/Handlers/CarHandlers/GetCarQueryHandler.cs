using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;


namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();

           return value.Select(x => new GetCarQueryResult
            {
               BrandID = x.BrandID,
               Model = x.Model,
               BigImageUrl = x.BigImageUrl,
               CoverImageUrl = x.CoverImageUrl,
               Fuel = x.Fuel,
               Km = x.Km,
               Luggage  = x.Luggage,
               Seat = x.Seat,
               Transmission = x.Transmission,
            }).ToList();
        }
    }
}
