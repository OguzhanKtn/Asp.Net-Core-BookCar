using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CarID);

            value.BrandID = request.BrandID;
            value.Model = request.Model;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Km = request.Km;
            value.Transmission = request.Transmission;
            value.Seat = request.Seat;
            value.Luggage = request.Luggage;
            value.Fuel = request.Fuel;
            value.BigImageUrl = request.BigImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
