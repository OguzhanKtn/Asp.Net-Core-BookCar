using Application.Features.CQRS.Queries.RentACarQueries;
using Application.Features.CQRS.Results.RentACarResults;
using Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);
            var results = values.Select(y => new GetRentACarQueryResult
            {
                CarID = y.CarID,
                Brand = y.Car.Brand.Name,
                Model = y.Car.Model,
                CoverImageUrl = y.Car.CoverImageUrl,
            }).ToList();
            return results;
        }
    }
}
