using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveBannerCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
