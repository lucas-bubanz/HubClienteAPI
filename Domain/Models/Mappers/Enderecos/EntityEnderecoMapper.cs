using Domain.Models.Entities;

namespace Domain.Models.Mappers.Enderecos
{
    public class EntityEnderecoMapper
    {
        public static Endereco Map(Endereco endereco)
        {
            return new Endereco
            {
                Bairro = endereco.Bairro,
                Complemento = endereco.Complemento,
                Localidade = endereco.Localidade,
                Logradouro = endereco.Logradouro,
                Uf = endereco.Uf,
                Estado = endereco.Estado,
                Regiao = endereco.Regiao
            };
        }
    }
}