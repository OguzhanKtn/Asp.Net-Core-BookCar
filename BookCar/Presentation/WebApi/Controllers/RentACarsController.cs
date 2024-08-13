using Application.Features.CQRS.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int locationID,bool available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                LocationID = locationID,
                Available = available
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
    }
}
