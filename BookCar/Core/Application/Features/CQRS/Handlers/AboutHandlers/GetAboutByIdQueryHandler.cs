using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                // Null bir değere erişildiğinde uygun bir yanıt veya hata fırlatabilirsiniz
                throw new Exception(nameof(About));
            }

            return new GetAboutByIdQueryResult()
            {
                Id = value.AboutID,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
            };
        }
    }
}
