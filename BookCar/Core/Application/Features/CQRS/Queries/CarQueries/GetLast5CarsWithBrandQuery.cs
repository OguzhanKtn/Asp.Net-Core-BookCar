﻿using Application.Features.CQRS.Results.CarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetLast5CarsWithBrandQuery : IRequest<IEnumerable<GetLast5CarsWithBrandQueryResult>>
    {
    }
}