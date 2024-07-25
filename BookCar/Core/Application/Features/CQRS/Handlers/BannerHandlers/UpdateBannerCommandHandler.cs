using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetByIdAsync(request.Id);

            banner.Title = request.Title;
            banner.Description = request.Description;
            banner.VideoUrl = request.VideoUrl;
            banner.VideoDescription = request.VideoDescription;

            await _repository.UpdateAsync(banner);
        }
    }
}
