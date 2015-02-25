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
	public class WhenSearchingHearthstoneCards : HearthstoneCardCacheContext
	{
		protected IEnumerable<ICard> _result;
		protected string query;
	    protected string playerClass;

		protected override void Context()
		{
			query = string.Empty;
		    playerClass = string.Empty;
		}

		protected override void Because()
		{
			_result = _hearthstoneCardCache.Query(new SearchCardsQuery(query, playerClass));
		}

	    protected override IEnumerable<ICard> Cards()
	    {
	        return new List<ICard>(base.Cards())
	        {
	            CreateRandomHeroCardWithId("HERO_10"),
	            CreateRandomHeroCardWithId("HERO_11"),
	            CreateRandomHeroCardWithId("HERO_12")
	        };
	    }

	    [Test]
		public void ShouldFilterOutHeroCards()
		{
		    _result.Any(x => x.Id.StartsWith("HERO")).ShouldEqual(false);
		}
	}
}