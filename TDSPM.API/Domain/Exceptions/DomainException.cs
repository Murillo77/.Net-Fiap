namespace TDSPM.API.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
            //Criar o log
        }
    }
}
