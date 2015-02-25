using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class CardsSearchViewModel
    {
        public IEnumerable<string> PlayerClasses { get; set; }
        public IEnumerable<CardModel> Cards { get; set; }
        public string SearchTerm { get; set; }
    }
}