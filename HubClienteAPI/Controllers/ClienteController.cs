using Domain.Commands.Clientes.CadastrarCliente;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HubClienteAPI.Controllers
{
    [ApiController]
    [Route("hub-cliente/v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteValueObject>> AdicionarCliente([FromBody] CadastraClienteCommand command)
        {
            var result = await _mediator.Send(command);
            if (result is null) return BadRequest();

            return Created(string.Empty, result);
        }
    }
}