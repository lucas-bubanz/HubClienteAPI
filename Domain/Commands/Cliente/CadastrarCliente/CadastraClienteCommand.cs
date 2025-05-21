using Domain.Responses;
using MediatR;

namespace Domain.Commands.Cliente.CadastrarClienteAsync
{
    public class CadastraClienteCommand : IRequest<ClienteResponse>
    {
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public string? CepCliente { get; set; }
    }
}