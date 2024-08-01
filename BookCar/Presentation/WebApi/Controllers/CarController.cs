using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Queries.CarPricingQueries;
using Application.Features.CQRS.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _mediator.Send(new GetCarByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return Ok("Başarıyla Silindi");
        }

        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = await _mediator.Send(new GetCarWithBrandQuery());
            return Ok(values);
        }
        [HttpGet("GetLast5CarsWithBrand")]
        public async Task<IActionResult> GetLast5CarsWithBrand()
        {
            var values = await _mediator.Send(new GetLast5CarsWithBrandQuery());
            return Ok(values);
        }
        [HttpGet("GetCarPricingWithCar")]
        public async Task<IActionResult> GetCarPricingWithCar()
        {
            var values = await _mediator.Send(new GetCarPricingQuery());
            return Ok(values);
        }
    }
}
