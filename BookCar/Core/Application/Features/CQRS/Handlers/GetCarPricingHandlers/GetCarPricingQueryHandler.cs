using Application.Features.CQRS.Queries.CarPricingQueries;
using Application.Features.CQRS.Results.CarPricingResults;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.GetCarPricingHandlers
{
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, IEnumerable<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingQueryResult()
            {
               Amount = x.Amount,
               Brand = x.Car.Brand.Name,
               CarPricingId = x.CarPricingID,
               CoverImageUrl = x.Car.CoverImageUrl,
               Model = x.Car.Model
            }).ToList();
        }
    }
}
