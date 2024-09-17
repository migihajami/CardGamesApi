using CGA.Common.Exceptions;
using CGA.Common.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Testing.Common.Models
{
    [TestClass]
    public class ShuffleMachineTests
    {
        [TestMethod]
        public void CheckInitializing()
        {
            var shuffleMachine = new ShuffleMachineTester(6);
            shuffleMachine.GetFreeCards().Should().HaveCount(52 * 6);
            shuffleMachine.GetCards().Should().BeEmpty();
        }

        [TestMethod]
        public void Hit()
        {
            var shuffleMachine = new ShuffleMachine(6);
            shuffleMachine.Stir();

            var cards = new List<Card>();
            for (var i = 0; i < 18; i++)
                cards.Add(shuffleMachine.Hit());

            cards.Distinct().Should().HaveCountGreaterThan(2);
        }

        [TestMethod]
        public void Hit_Empty()
        {
            var shuffleMachine = new ShuffleMachine(6);
            Action act = () => shuffleMachine.Hit();
            act.Should().Throw<EmptyBoxException>();
        }


        [TestMethod]
        public void Stir()
        {
            var shuffleMachine = new ShuffleMachineTester(6);
            shuffleMachine.Stir();
            shuffleMachine.GetCards().Should().HaveCount(6 * 52);
            shuffleMachine.GetFreeCards().Should().BeEmpty();
        }

        [TestMethod]
        public void Stir_FreeCards()
        {
            var shuffleMachine = new ShuffleMachineTester(6);
            shuffleMachine.Stir();

            for (var i = 0; i < 50; i++)
                _ = shuffleMachine.Hit();

            shuffleMachine.GetCards().Should().HaveCount(6 * 52 - 50);
            shuffleMachine.GetFreeCards().Should().HaveCount(50);

            shuffleMachine.StirFreeCards();
            shuffleMachine.GetCards().Should().HaveCount(6 * 52);
            shuffleMachine.GetFreeCards().Should().BeEmpty();
        }
    }

    class ShuffleMachineTester : ShuffleMachine
    {
        public ShuffleMachineTester(int deckAmount) : base(deckAmount)
        {

        }

        public List<Card> GetCards()
        {
            return Cards;
        }

        public List<Card> GetFreeCards()
        {
            return FreeCards;
        }
    }
}
