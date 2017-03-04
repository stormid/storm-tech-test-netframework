using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class CardsSearchViewModel
    {
        public IEnumerable<string> PlayerClasses { get; set; }
        public IEnumerable<CardModel> Cards { get; set; }
        public string SearchTerm { get; set; }
        public string PlayerClass { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCards { get; set; }
    }
}