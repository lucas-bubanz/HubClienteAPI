using AutoMapper;
using Domain.Commands.Clientes.CadastrarCliente;
using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteValueObject, Cliente>();
            CreateMap<Cliente, ClienteValueObject>();
            CreateMap<CadastraClienteCommand, ClienteValueObject>();
        }
    }
}