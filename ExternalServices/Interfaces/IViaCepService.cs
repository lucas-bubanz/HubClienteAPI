using ExternalServices.Models.Response;

namespace ExternalServices.Interfaces
{
    public interface IViaCepService
    {
        Task<ExternalViaCepResponse> ConsultarCepAsync(string cep);
    }
}