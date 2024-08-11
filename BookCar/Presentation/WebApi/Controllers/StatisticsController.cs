using Application.Features.CQRS.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public IActionResult GetCarCount()
        {
            var values = _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public IActionResult GetBrandNameByMaxCar()
        {
            var value = _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForDaily")]
        public IActionResult GetAvgRentPriceForDaily()
        {
            var value = _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public IActionResult GetAvgRentPriceForMonthly()
        {
            var value = _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentPriceForWeekly")]
        public IActionResult GetAvgRentPriceForWeekly()
        {
            var value = _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(value);
        }
        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var value = _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        } 
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public IActionResult GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public IActionResult GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelDiesel")]
        public IActionResult GetCarCountByFuelDiesel()
        {
            var value = _mediator.Send(new GetCarCountByFuelDieselQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelElectric")]
        public IActionResult GetCarCountByFuelElectric()
        {
            var value = _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(value);
        } 
        [HttpGet("GetCarCountByFuelGasoline")]
        public IActionResult GetCarCountByFuelGasoline()
        {
            var value = _mediator.Send(new GetCarCountByFuelGasolineQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByKmSmallerThan1000")]
        public IActionResult GetCarCountByKmSmallerThan1000()
        {
            var value = _mediator.Send(new GetCarCountByKmSmallerThan1000Query());
            return Ok(value);
        }
        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public IActionResult GetCarCountByTransmissionIsAuto()
        {
            var value = _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(value);
        }
        [HttpGet("GetLocationCount")]
        public IActionResult GetLocationCount()
        {
            var value = _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }
    }
}
