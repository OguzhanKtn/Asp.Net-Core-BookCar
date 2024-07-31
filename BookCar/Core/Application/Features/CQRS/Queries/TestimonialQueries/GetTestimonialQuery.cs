using Application.Features.CQRS.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<IEnumerable<GetTestimonialQueryResult>>
    {
    }
}
