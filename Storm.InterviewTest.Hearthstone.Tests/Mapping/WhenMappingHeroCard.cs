using AutoMapper;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
	public class WhenMappingHeroCard : MappingCardsContext
	{
		protected HeroModel _result;
		protected HeroCard _card;

		protected override void Context()
		{
			_card = new HeroCard("M1")
			{
				PlayerClass = "Priest",
				Name = "Anduin",
				Faction = FactionTypeOptions.Neutral,
				Rarity = RarityTypeOptions.Legendary,
				Attack = 0,
				Cost = 0,
				Health = 30
			};
		}

		protected override void Because()
		{
			_result = _mapper.Map<HeroCard, HeroModel>(_card);
		}

		[Test]
		public void ShouldMapHeroModelCorrectly()
		{
			_result.Name.ShouldEqual(_card.Name);
			_result.ImageUrl.ShouldEqual(_card.ImageUrl);
			_result.PlayerClass.ShouldBeNull();
			_result.PlayerClass.ShouldBeNull();
			_result.Health.ShouldEqual(_card.Health);
			_result.Attack.ShouldEqual(_card.Attack);
		}
	}
}