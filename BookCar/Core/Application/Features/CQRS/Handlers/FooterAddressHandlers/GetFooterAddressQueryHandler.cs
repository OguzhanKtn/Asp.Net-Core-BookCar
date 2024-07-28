using Application.Features.CQRS.Queries.FooterAddressQueries;
using Application.Features.CQRS.Results.FooterAddressResults;
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
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAdress> repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAdress> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            return values.Select(x => new GetFooterAddressQueryResult()
            {
                Description = x.Description,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,         
            }).ToList();
        }
    }
}
