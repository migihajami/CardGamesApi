
namespace CGA.Common.Exceptions
{
    public class BoxAlreadyFreeException : Exception
    {
        public BoxAlreadyFreeException(int boxId) : base($"The box '{boxId}' is already free") { }
    }
}
