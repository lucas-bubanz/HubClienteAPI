using Domain.Models.Entities;
using Domain.ValueObjects;

namespace Domain.Models.Mappers.Clientes
{
    public class EntityClienteMapper
    {
        public static Cliente Map(ClienteValueObject valueObject)
        {
            return new Cliente
            {
                CodigoCliente = valueObject.CodigoCliente,
                NomeCliente = valueObject.NomeCliente,
                EmailCliente = valueObject.EmailCliente,
                CepCliente = valueObject.CepCliente
            };
        }
    }
}