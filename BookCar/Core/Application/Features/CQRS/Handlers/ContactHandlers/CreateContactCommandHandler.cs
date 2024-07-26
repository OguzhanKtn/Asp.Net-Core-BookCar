using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;


namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Contact()
            {
                Name = request.Name,
                Email = request.Email,
                Subject = request.Subject,
                Phone = request.Phone,
                Message = request.Message,
                SendDate = request.SendDate,
            });
        }
    }
}
