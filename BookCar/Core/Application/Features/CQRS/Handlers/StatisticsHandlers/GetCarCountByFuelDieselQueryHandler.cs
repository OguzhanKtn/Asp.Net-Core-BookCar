using Application.Features.CQRS.Queries.StatisticsQueries;
using Application.Features.CQRS.Results.StatisticsResults;
using Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.StatisticsHandlers
{
    public class GetCarCountByFuelDieselQueryHandler : IRequestHandler<GetCarCountByFuelDieselQuery, GetCarCountByFuelDieselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelDieselQueryResult> Handle(GetCarCountByFuelDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelDiesel();
            return new GetCarCountByFuelDieselQueryResult()
            {
                CarCountByFuelDiesel = value,
            };
        }
    }
}
