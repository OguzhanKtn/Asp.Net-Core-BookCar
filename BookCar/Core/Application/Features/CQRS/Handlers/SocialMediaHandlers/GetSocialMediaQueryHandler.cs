using Application.Features.CQRS.Queries.SocialMediaQueries;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
           return values.Select(x => new GetSocialMediaQueryResult()
            {
               Name = x.Name,
               Icon = x.Icon,
               Url = x.Url,
            }).ToList();
        }
    }
}
