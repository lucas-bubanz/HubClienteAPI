using System.Net.Http.Json;
using ExternalServices.Interfaces;
using ExternalServices.Models.Response;

namespace ExternalServices.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "https://viacep.com.br/ws/";

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ExternalViaCepResponse> ConsultarCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}{cep}/json");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ExternalViaCepResponse>() ?? throw new InvalidOperationException("Falha no deserialize Response.");
            return result;
        }
    }
}