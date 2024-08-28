using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _mediator.Send(new GetContactQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _mediator.Send(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _mediator.Send(new RemoveContactCommand(id));
            return Ok("Başarıyla Silindi");
        }
    }
}
