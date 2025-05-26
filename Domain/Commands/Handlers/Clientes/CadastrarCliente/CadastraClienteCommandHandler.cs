using Domain.Commands.Clientes.CadastrarCliente;
using Domain.Exceptions;
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
            ExternalViaCepService externalViaCepService,
            CadastrarClienteValidator validator
        )
        {
            _clienteRepository = clienteRepository;
            _externalViaCepService = externalViaCepService;
            _validator = validator;
        }
        public async Task<ClienteResponse> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {            
            try
            {
                var clienteRequest = ValueObjectClienteMapper.Map(request);
                var resultadoValidator = await _validator.ValidateAsync(clienteRequest, cancellationToken);

                if (!resultadoValidator.IsValid || String.IsNullOrEmpty(clienteRequest.CepCliente))
                {
                    return new ClienteResponse 
                    { 
                        Errors = [.. resultadoValidator.Errors.Select(e => e.ErrorMessage)]
                    };
                }

                var enderecoCliente = await _externalViaCepService.ConsultaApiCep(clienteRequest.CepCliente)
                    ?? throw new ValidacaoException(["Endereço não encontrado para o CEP informado"]);

                var entidade = EntityClienteMapper.Map(clienteRequest, enderecoCliente);
                await _clienteRepository.CadastrarClienteAsync(entidade);

                return new ClienteResponse { CodigoCliente = entidade.CodigoCliente, NomeCliente = entidade.NomeCliente };   
            }
            catch (Exception ex) when (ex is not ValidacaoException)
            {
                return new ClienteResponse 
                { 
                    Errors = ["Erro interno ao processar a requisição"]
                };
            }            
        }
    }
}