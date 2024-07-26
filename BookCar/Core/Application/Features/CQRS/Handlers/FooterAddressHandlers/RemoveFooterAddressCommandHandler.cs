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
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public RemoveFooterAddressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            await _repository.RemoveAsync(value);
        }
    }
}
