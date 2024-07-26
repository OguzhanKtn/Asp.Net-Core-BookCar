using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Car()
            {
                BrandID = request.BrandID,
                Model = request.Model,
                CoverImageUrl = request.CoverImageUrl,
                Km=request.Km,
                Transmission = request.Transmission,
                Seat = request.Seat,
                Luggage = request.Luggage,
                Fuel = request.Fuel,
                BigImageUrl = request.BigImageUrl,
            });
        }
    }
}
