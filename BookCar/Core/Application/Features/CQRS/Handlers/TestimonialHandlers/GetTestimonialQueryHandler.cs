using Application.Features.CQRS.Queries.TestimonialQueries;
using Application.Features.CQRS.Results.TestimonialResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, IEnumerable<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetTestimonialQueryResult()
            {
                Id = x.TestimonialID,
                Name = x.Name,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                Comment = x.Comment
            }).ToList();
        }
    }
}
