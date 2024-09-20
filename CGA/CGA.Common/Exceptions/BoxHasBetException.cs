
namespace CGA.Common.Exceptions
{
    public class BoxHasBetException : Exception
    {
        public BoxHasBetException(int boxId) : base($"The box '{boxId}' has a bet") { }
    }
}
