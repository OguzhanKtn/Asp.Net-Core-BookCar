﻿using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Başarıyla Silindi");
        }
    }
}