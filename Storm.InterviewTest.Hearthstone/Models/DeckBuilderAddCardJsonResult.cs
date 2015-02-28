using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class DeckBuilderAddCardJsonResult
    {
        public bool Success { get; set; }
        public string CardId { get; set; }
        public string CardName { get; set; }
        public string ErrorMessage { get; set; }
    }
}