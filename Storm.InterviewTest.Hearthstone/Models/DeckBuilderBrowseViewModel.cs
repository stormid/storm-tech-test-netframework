using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Models;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class DeckBuilderBrowseViewModel
    {
        public IEnumerable<DeckModel> Decks { get; set; }
        public IEnumerable<CardModel> Heroes { get; set; } 
    }
}