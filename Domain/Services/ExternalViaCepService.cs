using Domain.Models.Mappers.ViaCep;
using Domain.Responses;
using ExternalServices.Interfaces;

namespace Domain.Services
{
    public class ExternalViaCepService
    {
        private readonly IViaCepService _viaCepService;
        public ExternalViaCepService(IViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }

        public async Task<ViaCepResponse> ConsultaApiCep(string cep)
        {
            var result = await _viaCepService.ConsultarCepAsync(cep);            
            var response = CepResponseMapper.Map(result);

            return response;
        }
    }
}