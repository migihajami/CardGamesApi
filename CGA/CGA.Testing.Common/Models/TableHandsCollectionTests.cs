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
    public class TableHandsCollectionTests
    {
        [TestMethod]
        public void TableHandsCollectionTest_Constructor()
        {
            var thCollection = new TableBoxCollection(6);
            thCollection.GetFreeBoxes().Should().HaveCount(6);
            thCollection.TotalBoxCount().Should().Be(6);
        }

        [TestMethod]
        public void TableHandsCollectionTest_Constructor2()
        {
            var preparedList = new List<TableBox>() 
            { 
                new TableBox{ BetAmount = 25, PlayerId = Guid.NewGuid(), TableBoxId = 0 },
                new TableBox{ BetAmount = 50, PlayerId = Guid.NewGuid(), TableBoxId = 1 },
                new TableBox{ BetAmount = 250, PlayerId = Guid.NewGuid(), TableBoxId = 2 },
                new TableBox{ BetAmount = 0, PlayerId = null, TableBoxId = 3 },
                new TableBox{ BetAmount = 0, PlayerId = null, TableBoxId = 4 },
                new TableBox{ BetAmount = 0, PlayerId = null, TableBoxId = 5 },
            };

            var thCollection = new TableBoxCollection(preparedList);
            thCollection.GetFreeBoxes().Should().HaveCount(3);
            thCollection.TotalBoxCount().Should().Be(6);
        }

        [TestMethod]
        public void MakeBet_Success()
        {
            var thCollection = new TableBoxCollection(1);
            thCollection.Occupy(Guid.NewGuid(), 0).Should().BeTrue();
            thCollection.MakeBet(0, 250);
            thCollection.First().BetAmount.Should().Be(250);
        }

        [TestMethod]
        public void MakeBet_Fail()
        {
            var thCollection = new TableBoxCollection(1);
            thCollection.Occupy(Guid.NewGuid(), 0).Should().BeTrue();
            Action act = () => thCollection.MakeBet(0, 250);
            act.Should().NotThrow();
            act.Should().Throw<BoxHasBetException>();
        }

        [TestMethod]
        public void Occupy_Success()
        {
            var thCollection = new TableBoxCollection(6);
            var playerId = Guid.NewGuid();
            thCollection.Occupy(playerId, 0).Should().BeTrue();
            thCollection.FreeBoxCount().Should().Be(5);
            thCollection.First().PlayerId.Should().Be(playerId);
        }

        [TestMethod]
        public void Occupy_Fail()
        {
            var thCollection = new TableBoxCollection(1);
            thCollection.Occupy(Guid.NewGuid(), 0).Should().BeTrue();
            thCollection.Occupy(Guid.NewGuid(), 0).Should().BeFalse();
        }

        [TestMethod]
        public void Free_Success()
        {
            var thCollection = new TableBoxCollection(6);
            thCollection.Occupy(Guid.NewGuid(), 0).Should().BeTrue();
            thCollection.Occupy(Guid.NewGuid(), 1).Should().BeTrue();

            thCollection.Free(0);
            thCollection.GetFreeBoxes().Should().Contain(0);
        }

        [TestMethod]
        public void Free_Fail_HasBet()
        {
            var thCollection = new TableBoxCollection(6);
            thCollection.Occupy(Guid.NewGuid(), 0).Should().BeTrue();
            thCollection.Occupy(Guid.NewGuid(), 1).Should().BeTrue();
            thCollection.MakeBet(0, 250);

            Action act = () => thCollection.Free(0);
            act.Should().Throw<BoxHasBetException>();
        }

        [TestMethod]
        public void Free_Fail_AlreadyFree()
        {
            var thCollection = new TableBoxCollection(6);
            thCollection.Occupy(Guid.NewGuid(), 0).Should().BeTrue();
            thCollection.Occupy(Guid.NewGuid(), 1).Should().BeTrue();


            Action act = () => thCollection.Free(0);
            act.Should().NotThrow<BoxAlreadyFreeException>();
            act.Should().Throw<BoxAlreadyFreeException>();
        }
    }
}
