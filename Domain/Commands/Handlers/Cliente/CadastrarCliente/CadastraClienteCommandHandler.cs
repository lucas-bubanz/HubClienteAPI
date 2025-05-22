using AutoMapper;
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
        private readonly IMapper _mapper;
        public CadastraClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<ClienteResponse> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {

            var clienteVO = new ClienteValueObject
            {
                NomeCliente = request.NomeCliente,
                EmailCliente = request.EmailCliente,
                CepCliente = request.CepCliente
            };

            var entidade = _mapper.Map<Domain.Entities.Cliente>(clienteVO);
            await _clienteRepository.CadastrarClienteAsync(entidade);

            return new ClienteResponse { CodigoCliente = entidade.CodigoCliente };
        }
    }
}