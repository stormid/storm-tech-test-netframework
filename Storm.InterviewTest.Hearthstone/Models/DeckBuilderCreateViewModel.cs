using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class DeckBuilderCreateViewModel
    {
        public CardModel HeroCard { get; set; }
        public IEnumerable<CardModel> AvailableCards { get; set; } 
    }
}