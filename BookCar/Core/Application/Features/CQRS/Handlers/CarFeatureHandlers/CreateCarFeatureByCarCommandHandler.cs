using Application.Features.CQRS.Commands.CarFeaturesCommand;
using Application.Interfaces.CarInterfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            List<CarFeature> carFeatures = new List<CarFeature>();
            foreach(var item in request.CarFeatures)
            {
                carFeatures.Add(new CarFeature
                {
                    CarID = item.CarID,
                    FeatureID = item.FeatureID,
                    Available = item.Available
                });
            }
             _repository.CreateCarFeatureByCar(carFeatures);
        }
    }
}
