using Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.CarFeaturesCommand
{
    public class CreateCarFeatureByCarCommand : IRequest
    {
        public List<CarFeatureViewModel> CarFeatures { get; set; }
    }
}
