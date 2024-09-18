
namespace CGA.Common.Exceptions
{
    public class HitOnDoubledHandException : Exception
    {
        public HitOnDoubledHandException() : base("You cannot hit on doubled hand") { }
    }
}
