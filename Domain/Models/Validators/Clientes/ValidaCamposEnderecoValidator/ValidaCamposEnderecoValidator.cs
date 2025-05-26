using Domain.Responses;
using FluentValidation;

namespace Domain.Models.Validators.Clientes.ValidaCamposEnderecoValidator
{
    public class ValidaCamposEnderecoValidator : AbstractValidator<ViaCepResponse>
    {
        public ValidaCamposEnderecoValidator()
        {
            RuleFor(e => e.Localidade)
                .NotEmpty()                
                .WithMessage("A Localidade não pode ser nula.");
            RuleFor(e => e.Uf)
                .NotEmpty()                
                .WithMessage("o UF não pode ser nulo.");
            RuleFor(e => e.Estado)
                .NotEmpty()                
                .WithMessage("O Estado não pode ser nulo.");
        }
    }
}

