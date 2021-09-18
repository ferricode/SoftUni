namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> BattleCards = new Dictionary<int, BattleCard>();
        public void Add(BattleCard card)
        {
            this.BattleCards.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return this.BattleCards.ContainsKey(card.Id);

        }

        public int Count { get => this.BattleCards.Count; }

        private void Exists(int cardId)
        {
            if (!this.BattleCards.ContainsKey(cardId))
            {
                throw new InvalidOperationException();
            }
        }
        public void ChangeCardType(int id, CardType type)
        {
            Exists(id);
            this.BattleCards[id].Type = type;
        }

        public BattleCard GetById(int id)
        {
            Exists(id);
            return this.BattleCards[id];
        }

        public void RemoveById(int id)
        {
            Exists(id);
            this.BattleCards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            return FilteredAndOrderedByDamage(card => card.Type == type);

            //var cards = this.BattleCards
            //    .Select(kvp => kvp.Value)
            //    .Where(card => card.Type == type)
            //    .OrderByDescending(card => card.Damage)
            //    .OrderBy(card => card.Id);

            //if (cards.Count() == 0)
            //{
            //    throw new InvalidOperationException();
            //}
            //return cards;
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            return FilteredAndOrderedByDamage(card => card.Type == type && card.Damage > lo && card.Damage < hi);

            //var cards = this.BattleCards
            //    .Select(kvp => kvp.Value)
            //    .Where(card => card.Type == type && card.Damage > lo && card.Damage < hi)
            //    .OrderByDescending(card => card.Damage)
            //    .ThenBy(card => card.Id);


            //if (cards.Count() == 0)
            //{
            //    throw new InvalidOperationException();
            //}
            //return cards;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            return FilteredAndOrderedByDamage(card => card.Type == type && card.Damage <= damage);
            //var cards = this.BattleCards
            //     .Select(kvp => kvp.Value)
            //     .Where(card => card.Type == type && card.Damage <= damage)
            //     .OrderByDescending(card => card.Damage)
            //     .ThenBy(card => card.Id);

            //if (cards.Count() == 0)
            //{
            //    throw new InvalidOperationException();
            //}
            //return cards;
        }
        private IEnumerable<BattleCard> FilteredAndOrderedByDamage(Func<BattleCard, bool> predicate)
        {
            var cards = this.BattleCards
                     .Select(kvp => kvp.Value)
                     .Where(predicate)
                     .OrderByDescending(card => card.Damage)
                     .ThenBy(card => card.Id);

            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }
            return cards;
        }
        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var cards = this.BattleCards
                 .Select(kvp => kvp.Value)
                 .Where(card => card.Name == name)
                 .OrderByDescending(card => card.Swag)
                 .ThenBy(card => card.Id);

            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }
            return cards;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var cards = this.BattleCards
                 .Select(kvp => kvp.Value)
                 .Where(card => card.Name == name && card.Swag >= lo && card.Swag < hi)
                 .OrderByDescending(card => card.Swag)
                 .ThenBy(card => card.Id);

            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }
            return cards;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int cardCount)
        {
            if (cardCount > this.BattleCards.Count)
            {
                throw new InvalidOperationException();
            }
            var cards = this.BattleCards
                 .Select(kvp => kvp.Value)
                 .OrderBy(card => card.Swag)
                 .ThenBy(card => card.Id)
                 .Take(cardCount);
            return cards;

        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            var cards = this.BattleCards
                  .Select(kvp => kvp.Value)
                  .Where(card => card.Swag >= lo && card.Swag <= hi)
                  .OrderBy(card => card.Swag);

            return cards;
        }


        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var kvp in this.BattleCards)
            {
                yield return kvp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}