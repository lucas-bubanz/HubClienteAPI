using AutoMapper;
using Domain.Commands.Clientes.CadastrarCliente;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Responses;
using Domain.ValueObjects;
using MediatR;

namespace Domain.Commands.Handlers.Clientes.CadastrarCliente
{
    public class CadastraClienteCommandHandler : IRequestHandler<CadastraClienteCommand, ClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public CadastraClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<ClienteResponse> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {

            var clienteVO = _mapper.Map<ClienteValueObject>(request);
            var entidade = _mapper.Map<Cliente>(clienteVO);

            await _clienteRepository.CadastrarClienteAsync(entidade);

            return new ClienteResponse { CodigoCliente = entidade.CodigoCliente };
        }
    }
}