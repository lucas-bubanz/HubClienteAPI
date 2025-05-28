using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models.Mappers;
using Domain.Models.Mappers.Clientes;
using Domain.Models.Validators.Clientes.ValidaCamposEnderecoValidator;
using Domain.Services;
using MediatR;

namespace Domain.Commands.Clientes.CadastrarCliente
{
    public class CadastraClienteCommandHandler : IRequestHandler<CadastraClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ExternalViaCepService _externalViaCepService;
        private readonly CadastraClienteCommandValidator _validator;
        private readonly ValidaCamposEnderecoValidator _validaEndereco;
        public CadastraClienteCommandHandler
        (
            IClienteRepository clienteRepository,
            ExternalViaCepService externalViaCepService,
            CadastraClienteCommandValidator validator,
            ValidaCamposEnderecoValidator validaEndereco
        )
        {
            _clienteRepository = clienteRepository;
            _externalViaCepService = externalViaCepService;
            _validator = validator;
            _validaEndereco = validaEndereco;
        }
        public async Task<Guid> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {

            var requestValidator = await _validator.ValidateAsync(request, cancellationToken);
            if (!requestValidator.IsValid)
            {
                var erros = requestValidator.Errors.Select(e => e.ErrorMessage).ToList();                                
            }                

            var enderecoCliente = await _externalViaCepService.ConsultaApiCep(request.CepCliente);
            var enderecoValidator = await _validaEndereco.ValidateAsync(enderecoCliente, cancellationToken);

            if (!enderecoValidator.IsValid)
            {
                var erros = enderecoValidator.Errors.Select(e => e.ErrorMessage).ToList();                                
            }   

            var clienteRequest = ValueObjectClienteMapper.Map(request);
            var entidade = ValueObjectResponseMapper.Map(clienteRequest, enderecoCliente);
            await _clienteRepository.CadastrarClienteAsync(entidade);

            return entidade.CodigoCliente;
        }
    }
}