namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public interface IMinionCard : ICard
	{
		string Text { get; set; }
		int Health { get; set; }
		FactionTypeOptions Faction { get; set; }
	}
}