using Domain.Commands.Cliente.CadastrarClienteAsync;
using Domain.Interfaces;
using Domain.Responses;
using Domain.ValueObjects;
using MediatR;

namespace Domain.Commands.Handlers.Cliente.CadastrarCliente
{
    public class CadastraClienteCommandHandler : IRequestHandler<CadastraClienteCommand, ClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        public CadastraClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<ClienteResponse> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new ClienteValueObject
            {
                NomeCliente = request.NomeCliente,
                EmailCliente = request.EmailCliente,
                CepCliente = request.CepCliente
            };

            await _clienteRepository.CadastrarClienteAsync(cliente);

            return new ClienteResponse
            {
                NomeCliente = cliente.NomeCliente,
                Email = cliente.EmailCliente,
                Cep = cliente.CepCliente,
                Endereco = ""
            };
        }
    }
}