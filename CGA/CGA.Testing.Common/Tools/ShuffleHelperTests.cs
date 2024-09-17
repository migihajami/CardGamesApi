using CGA.Common.Tools;
using FluentAssertions;

namespace CGA.Testing.Common.Tools
{
    [TestClass]
    public class ShuffleHelperTests: ShuffleHelper
    {
        [TestMethod]
        public void GetNick_CorrectInput()
        {
            GetNick("Two", 2).Should().BeEquivalentTo("2");
            GetNick("Ten", 10).Should().BeEquivalentTo("10");
            GetNick("Jack", 10).Should().BeEquivalentTo("J");
            GetNick("Queen", 10).Should().BeEquivalentTo("Q");
            GetNick("King", 10).Should().BeEquivalentTo("K");
            GetNick("Ace", 11).Should().BeEquivalentTo("A");
        }

        [TestMethod]
        public void GetNick_IncorrectInput() 
        {
            Action act = () => GetNick("One", 1);
            act.Should().Throw<ArgumentException>();

            act = () => GetNick("Ace", 20);
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void GetDeck_Test()
        {
            var deck = GetDeck();
            deck.Should().NotBeNull();
            deck.Should().HaveCount(52);
            deck.Distinct().Should().HaveCount(52);
        }
    }
}
