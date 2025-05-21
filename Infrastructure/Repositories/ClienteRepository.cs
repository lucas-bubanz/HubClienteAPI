using Domain.Entities;
using Domain.Interfaces;
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

        public async Task CadastrarClienteAsync(ClienteValueObject clienteVO)
        {
            var cliente = new Cliente
            {
                CodigoCliente = clienteVO.CodigoCliente,
                NomeCliente = clienteVO.NomeCliente,
                EmailCliente = clienteVO.EmailCliente,
                CepCliente = clienteVO.CepCliente
            };

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