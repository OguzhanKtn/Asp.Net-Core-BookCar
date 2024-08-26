using Application.Features.CQRS.Queries.AppUserQueries;
using Application.Features.CQRS.Results.AppUserResults;
using Application.Interfaces;
using Application.Interfaces.AppUserInterfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository _repository;

        public GetCheckAppUserQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _repository.GetUserByFilterAsync(x => x.Username.Equals(request.Username) && x.Password.Equals(request.Password));
            if (user == null) 
            { 
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Username = user.Username;    
                values.Role = (await _repository.GetRoleByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
                values.Id = user.AppUserId;
            }
            return values;
        }
    }
}
