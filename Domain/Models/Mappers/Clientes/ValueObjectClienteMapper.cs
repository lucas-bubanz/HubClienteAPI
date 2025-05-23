using Domain.Commands.Clientes.CadastrarCliente;
using Domain.ValueObjects;

namespace Domain.Models.Mappers.Clientes
{
    public class ValueObjectClienteMapper
    {
        public static ClienteValueObject Map(CadastraClienteCommand command)
        {
            return new ClienteValueObject
            {
                NomeCliente = command.NomeCliente,
                EmailCliente = command.EmailCliente,
                CepCliente = command.CepCliente,
                CodigoCliente = Guid.NewGuid()
            };
        }
    }
}