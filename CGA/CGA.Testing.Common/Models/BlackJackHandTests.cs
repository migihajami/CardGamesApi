using CGA.Common.Enums;
using CGA.Common.Models;
using FluentAssertions;
using NSubstitute;

namespace CGA.Testing.Common.Models
{
    [TestClass]
    public class BlackJackHandTests
    {
        BlackJackHandTester _blackJackHand = new BlackJackHandTester();

        [TestInitialize]
        public void Initialize()
        {
            
        }

        [TestMethod]
        public void Hit()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Ace", 11, "A", SuitEnum.Clubs));

            var expectedCard = new Card("Ace", 11, "A", SuitEnum.Clubs);
            _blackJackHand.Hit(shuffleMachine);

            shuffleMachine.Received().Hit();
            var cards = _blackJackHand.GetCards();
            cards.Should().HaveCount(1);
            cards.Should().Contain(expectedCard);
        }

        [TestMethod]
        public void GetValue_WithoutAces()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Eight", 8, "8", SuitEnum.Clubs),
                new Card("Five", 5, "5", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs));

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(8);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(13);
            _blackJackHand.HasBlackJack.Should().BeFalse();

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(23);
            _blackJackHand.HasBlackJack.Should().BeFalse();
        }


        [TestMethod]
        public void GetValue_BlackJacks()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs));

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(11);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(21);
            _blackJackHand.HasBlackJack.Should().BeTrue();

            _blackJackHand.Flush();
            shuffleMachine.Hit().ReturnsForAnyArgs(
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("Ace", 11, "A", SuitEnum.Clubs));

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(10);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(21);
            _blackJackHand.HasBlackJack.Should().BeTrue();
        }


        [TestMethod]
        public void GetValues_WithAces()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("Five", 5, "5", SuitEnum.Clubs),
                new Card("Nine", 9, "9", SuitEnum.Clubs),
                new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("Five", 5, "5", SuitEnum.Clubs));

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(11);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(16);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(15);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(16);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(21);

            _blackJackHand.Flush();

            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs));

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(11);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(12);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(13);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(14);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(14);

            _blackJackHand.Hit(shuffleMachine);
            _blackJackHand.GetValue().Should().Be(24);

        }

        class BlackJackHandTester: BlackJackHand
        {
            
        }
    }
}
