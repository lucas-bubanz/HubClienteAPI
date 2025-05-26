using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Models.Validators.Clientes.CadastrarClienteValidator
{
    public class CadastrarClienteValidator : AbstractValidator<ClienteValueObject>
    {
        public CadastrarClienteValidator()
        {
            RuleFor(x => x.NomeCliente)
                .NotEmpty()
                .WithMessage("O nome do cliente é obrigatório")
                .Length(3, 100)
                .WithMessage("O nome deve ter entre 3 e 100 caracteres");

            RuleFor(x => x.CepCliente)
                .NotEmpty()
                .WithMessage("O CEP é obrigatório")
                .Length(8)
                .Must(cep => !string.IsNullOrWhiteSpace(cep) && ValidaFormatacaoCep(cep))
                .WithMessage("CEP inválido - deve conter 8 dígitos numéricos e sem formatação com '-'");

            RuleFor(x => x.EmailCliente)
                .NotEmpty()
                .WithMessage("O e-mail do cliente é obrigatório")
                .EmailAddress()
                .WithMessage("O e-mail do cliente não é válido");
        }
        private static bool ValidaFormatacaoCep(string cep)
        {                        
            return cep.All(char.IsDigit);
        }
    }    
}