﻿using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery getAboutByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getAboutByIdQuery.Id);
            return new GetAboutByIdQueryResult()
            {
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
            };
        }
    }
}
