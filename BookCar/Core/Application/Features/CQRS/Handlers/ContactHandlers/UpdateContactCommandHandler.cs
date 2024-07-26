using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ContactID);

            value.Phone = request.Phone;
            value.Name = request.Name;
            value.SendDate = request.SendDate;
            value.Message = request.Message;
            value.Email = request.Email;
            value.Subject = request.Subject;
            
            await _repository.UpdateAsync(value);
        }
    }
}
