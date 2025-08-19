namespace Hexagon.Shop.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string error) : base(error)
        {

        }

        public NotFoundException(string error, Exception innerException) : base(error, innerException)
        {
        }
    }
}
