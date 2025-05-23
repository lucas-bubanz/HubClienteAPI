using Domain.Commands.Clientes.CadastrarCliente;
using Domain.Interfaces;
using Domain.Models.Mappers.Clientes;
using Domain.Responses;
using Domain.Services;
using MediatR;

namespace Domain.Commands.Handlers.Clientes.CadastrarCliente
{
    public class CadastraClienteCommandHandler : IRequestHandler<CadastraClienteCommand, ClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ExternalViaCepService _externalViaCepService;
        public CadastraClienteCommandHandler(IClienteRepository clienteRepository, ExternalViaCepService externalViaCepService)
        {
            _clienteRepository = clienteRepository;
            _externalViaCepService = externalViaCepService;
        }
        public async Task<ClienteResponse> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {
            
            var cliente = ValueObjectClienteMapper.Map(request);            
            var enderecoCliente = await _externalViaCepService.ConsultaApiCep(cliente.CepCliente);
            var entidade = EntityClienteMapper.Map(cliente, enderecoCliente);
        
            await _clienteRepository.CadastrarClienteAsync(entidade);

            return new ClienteResponse { CodigoCliente = entidade.CodigoCliente, NomeCliente = entidade.NomeCliente };
        }
    }
}