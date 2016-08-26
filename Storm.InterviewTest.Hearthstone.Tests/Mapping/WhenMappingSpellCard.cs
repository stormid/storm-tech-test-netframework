using AutoMapper;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
	public class WhenMappingSpellCard : MappingCardsContext
	{
		protected SpellModel _result;
		protected SpellCard _card;

		protected override void Context()
		{
			_card = new SpellCard("M1")
			{
				PlayerClass = "Mage",
				Name = "Fireball",
				Faction = FactionTypeOptions.Neutral,
				Rarity = RarityTypeOptions.Common,
				Attack = 6,
				Cost = 9,
				Text = "Deal $6 fire damage"
			};
		}

		protected override void Because()
		{
			_result = _mapper.Map<SpellCard, SpellModel>(_card);
		}

		[Test]
		public void ShouldMapSpellModelCorrectly()
		{
			_result.Name.ShouldEqual(_card.Name);
			_result.ImageUrl.ShouldEqual(_card.ImageUrl);
			_result.PlayerClass.ShouldBeOfType(typeof(HeroModel));
			_result.PlayerClass.Name.ShouldEqual("My Hero");
			_result.Attack.ShouldEqual(_card.Attack);
		}
	}
}