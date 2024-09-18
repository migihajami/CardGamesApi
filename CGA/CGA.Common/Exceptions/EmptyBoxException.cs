
namespace CGA.Common.Exceptions
{
    public class EmptyBoxException: Exception
    {
        public EmptyBoxException(): base("Shuffle machine has no cards in the box") { }
    }
}
