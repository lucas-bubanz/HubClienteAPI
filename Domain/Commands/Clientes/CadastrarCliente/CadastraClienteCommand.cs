using Domain.Models.Mappers.Clientes;
using MediatR;

namespace Domain.Commands.Clientes.CadastrarCliente
{
    public class CadastraClienteCommand : IRequest<Guid>
    {
        public Guid Id { get; private set; }
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public string? CepCliente { get; set; }
    }
}