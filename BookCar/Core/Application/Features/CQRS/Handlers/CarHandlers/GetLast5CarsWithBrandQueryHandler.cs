using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler : IRequestHandler<GetLast5CarsWithBrandQuery, IEnumerable<GetLast5CarsWithBrandQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetLast5CarsWithBrandQueryResult>> Handle(GetLast5CarsWithBrandQuery request, CancellationToken cancellationToken)
        {
           var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandQueryResult()
            {
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
