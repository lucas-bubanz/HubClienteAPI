using Domain.Models.Entities;
using Domain.ValueObjects;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task CadastrarClienteAsync(Cliente cliente);
        Task AtualizarClienteAsync(ClienteValueObject cliente);
        Task DeletarClienteAsync(int id);
        Task<IEnumerable<ClienteValueObject>> ListarClientesAsync();
    }
}