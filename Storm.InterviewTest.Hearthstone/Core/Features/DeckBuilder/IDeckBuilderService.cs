using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder
{
    public interface IDeckBuilderService
    {
        IEnumerable<DeckModel> GetAllDecks();
        DeckModel GetDeck(string name);
        DeckModel CreateDeck(string name, string heroId);
        CardModel AddCardToDeck(string name, string id);
        void RemoveCardFromDeck(string name, string id);
    }
}