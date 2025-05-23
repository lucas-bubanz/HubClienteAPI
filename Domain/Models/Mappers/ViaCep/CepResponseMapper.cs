using Domain.Responses;
using ExternalServices.Models.Response;

namespace Domain.Models.Mappers.ViaCep
{
    public class CepResponseMapper
    {
        public static ViaCepResponse Map(ExternalViaCepResponse viaCepResponse)
        {
            return new ViaCepResponse
            {
                Logradouro = viaCepResponse.Logradouro,
                Complemento = viaCepResponse.Complemento,
                Bairro = viaCepResponse.Bairro,
                Localidade = viaCepResponse.Localidade,
                Uf = viaCepResponse.Uf
            };
        }
    }
}