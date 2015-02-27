using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Models
{
    public class DeckModel
    {
        public string Name { get; set; }
        public CardModel HeroModel { get; set; }
        public IEnumerable<CardModel> Cards { get; set; } 
    }
}