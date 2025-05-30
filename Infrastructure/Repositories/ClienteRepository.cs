using Domain.Interfaces;
using Domain.Models.Entities;
using Domain.ValueObjects;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly HubClienteContext _context;
        public ClienteRepository(HubClienteContext context)
        {
            _context = context;
        }
        public Task AtualizarClienteAsync(ClienteValueObject cliente)
        {
            throw new NotImplementedException();
        }

        public async Task CadastrarClienteAsync(Cliente cliente)
        {
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public Task DeletarClienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteValueObject>> ListarClientesAsync()
        {
            throw new NotImplementedException();
        }
    }
}