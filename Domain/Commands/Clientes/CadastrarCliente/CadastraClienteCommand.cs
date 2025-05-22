using Domain.Responses;
using MediatR;

namespace Domain.Commands.Clientes.CadastrarCliente
{
    public class CadastraClienteCommand : IRequest<ClienteResponse>
    {
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public string? CepCliente { get; set; }
    }
}