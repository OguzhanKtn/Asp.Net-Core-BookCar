using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetCarByIdQueryResult()
            {
                BrandID = value.BrandID,
                Model = value.Model,
                BigImageUrl = value.BigImageUrl,
                CoverImageUrl = value.CoverImageUrl,
                Fuel = value.Fuel,
                Km = value.Km,
                Luggage = value.Luggage,
                Seat = value.Seat,
                Transmission = value.Transmission,
            };
        }
    }
}
