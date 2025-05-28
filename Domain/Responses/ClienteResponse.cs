namespace Domain.Responses
{
    public class ClienteResponse
    {        
        public string? Id { get; set; }        
        public IEnumerable<string>? Errors { get; set; }
    }
}