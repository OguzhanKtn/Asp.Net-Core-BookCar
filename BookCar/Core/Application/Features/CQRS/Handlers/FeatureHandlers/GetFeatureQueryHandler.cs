using Application.Features.CQRS.Queries.FeatureQueries;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
           return values.Select(x => new GetFeatureQueryResult()
            {
               Id = x.FeatureID,
               Name = x.Name,
            }).ToList();
        }
    }
}
