using System;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public interface ICard
	{
		string Id { get; }
		string Name { get; set; }
		CardTypeOptions Type { get; }
        RarityTypeOptions Rarity { get; set; }
		int Cost { get; set; }
		int Attack { get; set; }
		string PlayerClass { get; set; }
		Uri ImageUrl { get; }
	}
}