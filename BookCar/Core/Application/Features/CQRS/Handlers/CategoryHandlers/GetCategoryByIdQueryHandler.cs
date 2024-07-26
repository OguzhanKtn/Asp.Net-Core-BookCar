using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;


namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetCategoryByIdQueryResult()
            {
                Name = value.Name,
            };
        }
    }
}
