using Domain.Responses;

namespace Domain.ValueObjects
{
    public class ClienteValueObject
    {
        public Guid CodigoCliente { get; set; }
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public string? CepCliente { get; set; }
    }
}