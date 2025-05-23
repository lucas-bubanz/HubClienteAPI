using Domain.Commands.Clientes.CadastrarCliente;
using Domain.Interfaces;
using Domain.Models.Mappers.Clientes;
using Domain.Responses;
using MediatR;

namespace Domain.Commands.Handlers.Clientes.CadastrarCliente
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

            var cliente = ValueObjectClienteMapper.Map(request);
            var entidade = EntityClienteMapper.Map(cliente);

            await _clienteRepository.CadastrarClienteAsync(entidade);

            return new ClienteResponse { CodigoCliente = entidade.CodigoCliente };
        }
    }
}