using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class RemoveBrandCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveBrandCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
