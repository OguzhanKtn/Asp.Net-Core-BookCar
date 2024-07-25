using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;


namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler : IRequestHandler<RemoveBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(banner);
        }
    }
}
