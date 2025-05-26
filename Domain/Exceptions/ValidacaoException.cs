namespace Domain.Exceptions
{
    public class ValidacaoException(List<string> errors) : Exception
    {
        public List<string> Errors { get; } = errors;
    }
}