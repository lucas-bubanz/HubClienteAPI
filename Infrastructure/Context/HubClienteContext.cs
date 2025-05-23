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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Endereco>(e => e.CodigoCliente);
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Endereco> endereco { get; set; }
    }
}