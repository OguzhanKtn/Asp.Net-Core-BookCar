using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Results.FeatureResults
{
    public class GetFeatureQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
