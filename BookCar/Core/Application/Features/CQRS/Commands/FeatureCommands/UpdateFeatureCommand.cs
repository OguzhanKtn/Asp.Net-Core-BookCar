using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.FeatureCommands
{
    public class UpdateFeatureCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
