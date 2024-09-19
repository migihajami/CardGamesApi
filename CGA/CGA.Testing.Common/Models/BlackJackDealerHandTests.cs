using CGA.Common.Enums;
using CGA.Common.Exceptions;
using CGA.Common.Interfaces;
using CGA.Common.Models;
using FluentAssertions;
using NSubstitute;

namespace CGA.Testing.Common.Models
{
    [TestClass]
    public class BlackJackDealerHandTests
    {
        IBlackJackDealerHand _hand = new BlackJackDealerHand();

        [TestInitialize]
        public void Initialize() 
        { 
            
        }

        [TestMethod]
        public void GetFirstCard()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Eight", 8, "8", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs));

            _hand.Hit(shuffleMachine);
            _hand.Hit(shuffleMachine);

            var expectedCard = new Card("Eight", 8, "8", SuitEnum.Clubs);
            _hand.GetFirstCard().Should().BeEquivalentTo(expectedCard);
        }

        [TestMethod]
        public void MakeHand_BlackJack()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs));

            var value = _hand.MakeHand(shuffleMachine);
            value.Should().Be(21);
            _hand.HasBlackJack.Should().BeTrue();
        }

        [TestMethod]
        public void MakeHand_21()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Eight", 8, "8", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs));

            var value = _hand.MakeHand(shuffleMachine);
            value.Should().Be(21);

        }

        [TestMethod]
        public void MakeHand_17()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Eight", 8, "8", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs),
                new Card("Six", 6, "6", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs));

            var value = _hand.MakeHand(shuffleMachine);
            value.Should().Be(17);

        }

        [TestMethod]
        public void MakeHand_Bust()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Eight", 8, "8", SuitEnum.Clubs),
                new Card("Eight", 8, "8", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs));

            var value = _hand.MakeHand(shuffleMachine);
            value.Should().Be(26);

        }

    }
}
