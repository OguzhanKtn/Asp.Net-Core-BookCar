using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAboutCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
