using Application.Features.CQRS.Commands.ServiceCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private IRepository<Service> _repository;

        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Service()
            {
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl,
            });
        }
    }
}
