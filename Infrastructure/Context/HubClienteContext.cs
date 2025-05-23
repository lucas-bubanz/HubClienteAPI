using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class HubClienteContext : DbContext
    {
        public HubClienteContext(DbContextOptions<HubClienteContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> clientes { get; set; }
    }
}