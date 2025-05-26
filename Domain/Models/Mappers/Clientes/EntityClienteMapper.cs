using Domain.Models.Entities;
using Domain.Responses;
using Domain.ValueObjects;

namespace Domain.Models.Mappers.Clientes
{
    public class EntityClienteMapper
    {
        public static Cliente Map(ClienteValueObject valueObject, ViaCepResponse viaCepResponse)
        {
            ArgumentNullException.ThrowIfNull(viaCepResponse);
            
            var endereco = new Endereco
            {
                Logradouro = viaCepResponse.Logradouro,
                Complemento = viaCepResponse.Complemento,
                Bairro = viaCepResponse.Bairro,
                Localidade = viaCepResponse.Localidade,
                Uf = viaCepResponse.Uf,
                CodigoCliente = valueObject.CodigoCliente,
                Estado = viaCepResponse.Estado,
                Regiao = viaCepResponse.Regiao
            };

            return new Cliente
            {
                CodigoCliente = valueObject.CodigoCliente,
                NomeCliente = valueObject.NomeCliente,
                EmailCliente = valueObject.EmailCliente,
                CepCliente = valueObject.CepCliente ?? string.Empty,
                Endereco = endereco
            };
        }
    }
}