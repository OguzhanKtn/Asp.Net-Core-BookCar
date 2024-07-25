using Application.Features.CQRS.Results.BrandResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandByIdQuery : IRequest<GetBrandByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBrandByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
