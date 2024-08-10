using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces.CarInterfaces;
using Domain.Entities;
using MediatR;


namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler : IRequestHandler<GetCarWithBrandQuery, List<GetCarWithBrandQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle(GetCarWithBrandQuery request, CancellationToken cancellationToken)
        {
           var values = _repository.GetCarsWithBrands();
            
           return values.Select(x => new GetCarWithBrandQueryResult 
           { 
                CarID = x.CarID,
                BrandName = x.Brand.Name,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Fuel = x.Fuel,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                BigImageUrl = x.BigImageUrl,
            }).ToList();
        }
    }
}
