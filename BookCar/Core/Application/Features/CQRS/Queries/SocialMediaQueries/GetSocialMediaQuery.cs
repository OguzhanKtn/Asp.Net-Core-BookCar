using Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
