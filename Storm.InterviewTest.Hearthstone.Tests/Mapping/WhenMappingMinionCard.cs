using AutoMapper;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
	public class WhenMappingMinionCard : MappingCardsContext
	{
		protected MinionModel _result;
		protected MinionCard _card;


		protected override void Context()
		{
			_card = new MinionCard("M1")
			{
				PlayerClass = "Warrior",
				Name = "Whirlwind",
				Faction = FactionTypeOptions.Alliance,
				Rarity = RarityTypeOptions.Legendary,
				Health = 10,
				Attack = 4,
				Cost = 9,
				Text = "It's just a card"
			};
		}

		protected override void Because()
		{
			_result = _mapper.Map<MinionCard, MinionModel>(_card);
		}

		[Test]
		public void ShouldMapMinionModelCorrectly()
		{
			_result.Name.ShouldEqual(_card.Name);
			_result.ImageUrl.ShouldEqual(_card.ImageUrl);
			_result.PlayerClass.ShouldBeOfType(typeof(HeroModel));
			_result.PlayerClass.Name.ShouldEqual("My Hero");
			_result.Health.ShouldEqual(_card.Health);
			_result.Attack.ShouldEqual(_card.Attack);
			_result.Health.ShouldEqual(_card.Health);
		}
	}
}