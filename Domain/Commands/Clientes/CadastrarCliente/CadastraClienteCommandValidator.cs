using FluentValidation;

namespace Domain.Commands.Clientes.CadastrarCliente
{
    public class CadastraClienteCommandValidator : AbstractValidator<CadastraClienteCommand>
    {
        public CadastraClienteCommandValidator()
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
                .Must(cep => !string.IsNullOrWhiteSpace(cep) && cep.All(char.IsDigit))
                .WithMessage("CEP inválido - deve conter 8 dígitos numéricos e sem formatação com '-'");

            RuleFor(x => x.EmailCliente)
                .NotEmpty()
                .WithMessage("O e-mail do cliente é obrigatório")
                .EmailAddress()
                .WithMessage("O e-mail do cliente não é válido");
        }
    }
}