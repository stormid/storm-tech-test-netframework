using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Models;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class DeckBuilderEditViewModel
    {
        public DeckModel Deck { get; set; }
        public IEnumerable<CardModel> AvailableCards { get; set; } 
    }
}