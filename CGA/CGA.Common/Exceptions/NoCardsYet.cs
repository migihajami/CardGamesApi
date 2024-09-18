namespace CGA.Common.Exceptions
{
    public class NoCardsYet : Exception
    {
        public NoCardsYet() : base("Hand does't have any cards yet") { }
    }
}
