using Domain.Commands.Clientes.CadastrarCliente;
using Domain.Interfaces;
using Domain.Models.Mappers.Clientes;
using Domain.Models.Validators.Clientes.CadastrarClienteValidator;
using Domain.Responses;
using Domain.Services;
using MediatR;

namespace Domain.Commands.Handlers.Clientes.CadastrarCliente
{
    public class CadastraClienteCommandHandler : IRequestHandler<CadastraClienteCommand, ClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ExternalViaCepService _externalViaCepService;
        private readonly CadastrarClienteValidator _validator;
        public CadastraClienteCommandHandler
        (
            IClienteRepository clienteRepository,
            ExternalViaCepService externalViaCepService
        )
        {
            _clienteRepository = clienteRepository;
            _externalViaCepService = externalViaCepService;
            _validator = new CadastrarClienteValidator();
        }
        public async Task<ClienteResponse> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {            
            var clienteRequest = ValueObjectClienteMapper.Map(request);

            if (string.IsNullOrWhiteSpace(clienteRequest.CepCliente) || !_validator.ValidaFormatacaoCep(clienteRequest.CepCliente))
                throw new Exception("O CPF digitado é inválido");
            
            var resultadoValidator = await _validator.ValidateAsync(clienteRequest, cancellationToken);

            if (!resultadoValidator.IsValid)
            {
                var erros = resultadoValidator.Errors.Select(e => e.ErrorMessage).ToList();                
            }                

            var enderecoCliente = await _externalViaCepService.ConsultaApiCep(clienteRequest.CepCliente);            
            
            var entidade = EntityClienteMapper.Map(clienteRequest, enderecoCliente);
            await _clienteRepository.CadastrarClienteAsync(entidade);

            return new ClienteResponse { CodigoCliente = entidade.CodigoCliente, NomeCliente = entidade.NomeCliente };
        }
    }
}