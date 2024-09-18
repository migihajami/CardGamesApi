using CGA.Common.Enums;
using CGA.Common.Exceptions;
using CGA.Common.Models;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Testing.Common.Models
{
    [TestClass]
    public class BlackJackPlayerHandTests
    {
        BlackJackPlayerHand _hand = new BlackJackPlayerHand();

        [TestMethod]
        public void Hit_On_BlackJack()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Ace", 11, "A", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs));

            _hand.Hit(shuffleMachine);
            _hand.Hit(shuffleMachine);


            Action act = () => _hand.Hit(shuffleMachine);
            act.Should().Throw<HitOn21Exception>();
        }

        [TestMethod]
        public void Hit_On_21()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Eight", 8, "8", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs));

            _hand.Hit(shuffleMachine);
            _hand.Hit(shuffleMachine);
            _hand.Hit(shuffleMachine);

            Action act = () => _hand.Hit(shuffleMachine);
            act.Should().Throw<HitOn21Exception>();
        }

        [TestMethod]
        public void Hit_On_Doubled()
        {
            var shuffleMachine = Substitute.For<IShuffleMachine>();
            shuffleMachine.Hit().ReturnsForAnyArgs(new Card("Eight", 8, "8", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs),
                new Card("King", 10, "K", SuitEnum.Clubs),
                new Card("Three", 3, "3", SuitEnum.Clubs));

            _hand.Hit(shuffleMachine);
            _hand.Hit(shuffleMachine);

            _hand.Double(shuffleMachine);

            Action act = () => _hand.Hit(shuffleMachine);
            act.Should().Throw<HitOnDoubledHandException>();
        }
    }
}
