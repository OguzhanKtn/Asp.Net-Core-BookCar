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
    public class GetCarCountByFuelGasolineQueryHandler : IRequestHandler<GetCarCountByFuelGasolineQuery, GetCarCountByFuelGasolineQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelGasolineQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelGasolineQueryResult> Handle(GetCarCountByFuelGasolineQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelGasoline();
            return new GetCarCountByFuelGasolineQueryResult()
            {
                CarCountByFuelGasoline = value,
            };
        }
    }
}
