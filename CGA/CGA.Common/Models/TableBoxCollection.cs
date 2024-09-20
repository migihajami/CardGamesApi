using CGA.Common.Exceptions;
using CGA.Common.Interfaces;
using System.Collections;

namespace CGA.Common.Models
{
    public class TableBoxCollection : ITableBoxCollection, IEnumerable<TableBox>
    {
        protected int MaximumBoxes;
        private List<TableBox> _tableBoxes;
        private object _locker = new object();

        public TableBoxCollection(int maxHands)
        {
            MaximumBoxes = maxHands;
            _tableBoxes = new List<TableBox>();
            for (int i = 0; i < maxHands; i++)
            {
                _tableBoxes.Add(new TableBox() { TableBoxId = i, BetAmount = 0, PlayerId = null });
            }
        }

        public TableBoxCollection(List<TableBox> tableBoxes)
        {
            MaximumBoxes = tableBoxes.Count;
            _tableBoxes = tableBoxes;
        }

        public IEnumerable<int> GetFreeBoxes()
        {
            var result = _tableBoxes
                .Where(hand => hand.IsFree)
                .Select(hand => hand.TableBoxId)
                .ToList();

            return result;
        }

        public bool Occupy(Guid playerId, int boxId)
        {
            var result = false;
            lock (_locker)
            {
                var hand = _tableBoxes[boxId];
                if (hand.IsFree)
                {
                    result = true;
                    hand.PlayerId = playerId;
                }
            }
            return result;
        }

        public void Free(int boxId)
        {
            lock (_locker)
            {
                var hand = _tableBoxes[boxId];

                if (hand.IsFree)
                    throw new BoxAlreadyFreeException(boxId);
                
                if (hand.BetAmount > 0)
                    throw new BoxHasBetException(boxId);

                hand.PlayerId = null;
            }
        }

        public IEnumerator<TableBox> GetEnumerator()
        {
            return _tableBoxes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int FreeBoxCount()
        {
            return _tableBoxes.Count(box => box.IsFree);
        }

        public int TotalBoxCount()
        {
            return MaximumBoxes;
        }

        public void MakeBet(int boxId, decimal betAmount)
        {
            if (_tableBoxes[boxId].BetAmount > 0)
                throw new BoxHasBetException(boxId);

            _tableBoxes[boxId].BetAmount = betAmount;
        }
    }
}
