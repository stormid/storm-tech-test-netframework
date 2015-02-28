using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Domain
{
    public class Deck
    {
        public string Name { get; set; }
        public string HeroCardId { get; set; }
        public string PlayerClass { get; set; }
        public IEnumerable<string> CardIds
        {
            get { return cardIds; }
        }

        private readonly IList<string> cardIds;

        public Deck()
        {
            cardIds = new List<string>();
        }
 
        public void AddCard(ICard card)
        {
            if (cardIds.Count == 30)
            {
                throw new InvalidOperationException("This deck already has 30 cards, no more cards can be added");
            }

            if (card.Type == CardTypeOptions.Hero)
            {
                throw new InvalidOperationException("You cannot add a Hero card to a deck");
            }

            if(card.PlayerClass != null && card.PlayerClass != PlayerClass)
            {
                throw new InvalidOperationException(string.Format("You can only add cards of class '{0}' to this deck", PlayerClass));
            }

            var allowedcount = GetAllowedCount(card.Rarity);
            if (cardIds.Count(x => x == card.Id) == allowedcount)
            {
                throw new InvalidOperationException(string.Format("You can have already added {0} copies of this card which is the maximum for a card of {1} rarity", allowedcount, card.Rarity));
            }

            cardIds.Add(card.Id);
        }

        public void RemoveCard(ICard card)
        {
            var cardId = cardIds.FirstOrDefault(x => x == card.Id);
            if (cardId != null)
            {
                cardIds.RemoveAt(cardIds.IndexOf(cardId));
            }
        }

        private int GetAllowedCount(RarityTypeOptions rarity)
        {
            switch (rarity)
            {
                case RarityTypeOptions.Epic:
                case RarityTypeOptions.Legendary:
                    return 1;
                default:
                    return 2;
            }
        }
    }
}