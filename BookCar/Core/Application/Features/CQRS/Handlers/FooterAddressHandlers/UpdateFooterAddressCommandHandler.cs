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
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            value.Description = request.Description;
            value.Address = request.Address;
            value.Phone = request.Phone;
            value.Email = request.Email;

            await _repository.UpdateAsync(value);
        }
    }
}
