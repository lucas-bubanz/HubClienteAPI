using System.Text.Json.Serialization;

namespace Domain.Responses
{
    public class ClienteResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid CodigoCliente { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NomeCliente { get; set; }    
        
        public List<string>? Errors { get; set; }
        public bool Success => Errors == null || !Errors.Any();
    }
}