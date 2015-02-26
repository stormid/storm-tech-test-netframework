using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder
{
    public class DeckModel
    {
        public string Name { get; set; }
        public HeroModel HeroModel { get; set; }
        public IEnumerable<CardModel> Cards { get; set; } 
    }
}