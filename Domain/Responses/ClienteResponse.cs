namespace Domain.Responses
{
    public class ClienteResponse
    {
        public string? NomeCliente { get; set; }
        public string? Email { get; set; }
        public string? Cep { get; set; }
        public string Endereco { get; set; } = string.Empty;
    }
}