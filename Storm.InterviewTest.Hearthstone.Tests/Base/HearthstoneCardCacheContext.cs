using System;
using System.Collections.Generic;
using System.ComponentModel;
using FizzWare.NBuilder;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Base
{
	[Category("Cache")]
	public abstract class HearthstoneCardCacheContext : ContextSpecification
	{
		protected IEnumerable<ICard> _cards;
		protected IHearthstoneCardCache _hearthstoneCardCache;

		protected ICard CreateRandomMinionCardWithId(string id)
		{
			return Builder<MinionCard>.CreateNew().WithConstructor(() => new MinionCard(id)).Build();
		}

		protected ICard CreateRandomMinionCardWithId(string id, Action<MinionCard> minionAction)
		{
			var minion = Builder<MinionCard>.CreateNew().WithConstructor(() => new MinionCard(id)).Build();
			minionAction.Invoke(minion);
			return minion;
		}

		protected ICard CreateRandomSpellCardWithId(string id, Action<SpellCard> spellAction = null)
		{
			var spell = Builder<SpellCard>.CreateNew().WithConstructor(() => new SpellCard(id)).Build();
		    if (spellAction != null)
		    {
		        spellAction.Invoke(spell);
		    }
		    return spell;
		}

		protected ICard CreateRandomWeaponCardWithId(string id)
		{
			return Builder<WeaponCard>.CreateNew().WithConstructor(() => new WeaponCard(id)).Build();
		}

	    protected ICard CreateRandomHeroCardWithId(string id)
	    {
	        return Builder<HeroCard>.CreateNew().WithConstructor(() => new HeroCard(id)).Build();
	    }

		protected override void SharedContext()
		{
			_cards = Cards();
			_hearthstoneCardCache = new HearthstoneCardCache(_cards);
		}

		protected virtual IEnumerable<ICard> Cards()
		{
			return new[]
			{
				CreateRandomMinionCardWithId("M1"),
				CreateRandomMinionCardWithId("M2"),
				CreateRandomSpellCardWithId("S1"),
				CreateRandomWeaponCardWithId("W1")
			};
		}
	}
}