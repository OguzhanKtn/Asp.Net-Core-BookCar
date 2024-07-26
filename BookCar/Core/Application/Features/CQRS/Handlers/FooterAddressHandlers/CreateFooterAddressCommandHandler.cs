using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAdress()
            {
                Description = request.Description,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
            });
        }
    }
}
