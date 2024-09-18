
using CGA.Common.Enums;
using CGA.Common.Models;
using FluentAssertions;

namespace CGA.Testing.Common.Models
{
    [TestClass]
    public class HandTests
    {
        private HandTester _hand = new HandTester();

        [TestInitialize]
        public void Initialize() 
        { 
            _hand = new HandTester();
        }

        [TestMethod]
        public void AddCard_Success()
        {
            _hand.AddCard(new Card("Ten", 10, "10", SuitEnum.Diamonds));
            _hand.AddCard(new Card("Ten", 10, "10", SuitEnum.Diamonds));

            _hand.GetCards().Should().HaveCount(2);
        }

        [TestMethod]
        public void AddCard_EmptyArgument()
        {
            Action act = () => _hand.AddCard(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Flush()
        {
            _hand.AddCard(new Card("Ten", 10, "10", SuitEnum.Diamonds));
            _hand.AddCard(new Card("Ten", 10, "10", SuitEnum.Diamonds));
            _hand.Flush();

            _hand.GetCards().Should().BeEmpty();
        }
    }

    class HandTester: Hand
    {

    }
}
