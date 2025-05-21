using Domain.ValueObjects;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task CadastrarClienteAsync(ClienteValueObject cliente);
        Task AtualizarClienteAsync(ClienteValueObject cliente);
        Task DeletarClienteAsync(int id);
        Task<IEnumerable<ClienteValueObject>> ListarClientesAsync();
    }
}