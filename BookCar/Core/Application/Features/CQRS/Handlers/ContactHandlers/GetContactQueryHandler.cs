using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResults;
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
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

          return  values.Select(x => new GetContactQueryResult()
            {
                ContactID = x.ContactID,
                Name = x.Name,
                Phone = x.Phone,
                Message = x.Message,
                Email = x.Email,
                Subject = x.Subject,
                SendDate = x.SendDate,
            }).ToList();
        }
    }
}
