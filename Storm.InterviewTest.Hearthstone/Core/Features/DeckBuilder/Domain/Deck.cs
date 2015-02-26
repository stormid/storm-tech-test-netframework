using System.Collections.Generic;
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
            // Return if we already have 30 cards or;
            // if the card is a hero card or;
            // if the card PlayerClass is not neutral or of the same type as our hero card
            if (cardIds.Count == 30 || 
                card.Type == CardTypeOptions.Hero ||
                card.PlayerClass != null && card.PlayerClass != PlayerClass)
            {
                return;
            }

            // Return if we already have the max amount of this specific card
            if (cardIds.Count(x => x == card.Id) == GetAllowedCount(card.Rarity))
            {
                return;
            }

            cardIds.Add(card.Id);
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