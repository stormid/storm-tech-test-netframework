namespace Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder
{
    public interface IDeckBuilderService
    {
        DeckModel GetDeck(string name);
        DeckModel CreateDeck(string name, string heroId);
        DeckModel AddCardToDeck(string name, string id);
    }
}