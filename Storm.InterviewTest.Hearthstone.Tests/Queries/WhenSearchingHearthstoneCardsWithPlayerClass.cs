using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Tests.Base;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
	[Category("Cache")]
	public class WhenSearchingHearthstoneCardsWithPlayerClass : HearthstoneCardCacheContext
	{
		protected IEnumerable<ICard> _result;
		protected string query;
	    protected string playerClass;

		protected override void Context()
		{
			query = string.Empty;
		    playerClass = "Mage";
		}

		protected override void Because()
		{
			_result = _hearthstoneCardCache.Query(new SearchCardsQuery(query, playerClass));
		}

        protected override IEnumerable<ICard> Cards()
        {
            return new List<ICard>
			{
				CreateRandomSpellCardWithId("99", spell =>
				{
					spell.Name = "Pew Pew Cannon";
				    spell.PlayerClass = "Mage";
				}),
                CreateRandomSpellCardWithId("100", spell =>
                {
                    spell.Name = "DEM LAZ0RZ";
                    spell.PlayerClass = "Mage";
                }),
                CreateRandomSpellCardWithId("101", spell =>
                {
                    spell.Name = "Mage Envy";
                    spell.PlayerClass = "Warrior";
                }),
                CreateRandomSpellCardWithId("102", spell =>
                {
                    spell.Name = "Double Damage";
                    spell.PlayerClass = "Shaman";
                }),
                CreateRandomSpellCardWithId("103", spell =>
                {
                    spell.Name = "Mages Hatin On These Heals";
                    spell.PlayerClass = "Priest";
                })
			};
        }


		[Test]
		public void ShouldReturnExpectedSearchResults()
		{
			_result.Count().ShouldEqual(2);
            _result.All(x => x.PlayerClass == "Mage").ShouldEqual(true);
		}
	}
}