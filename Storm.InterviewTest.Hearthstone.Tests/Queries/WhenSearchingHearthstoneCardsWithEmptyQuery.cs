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
	public class WhenSearchingHearthstoneCardsWithEmptyQuery : HearthstoneCardCacheContext
	{
		protected IEnumerable<ICard> _result;
		protected string query;

		protected override void Context()
		{
			query = string.Empty;
		}

		protected override void Because()
		{
			_result = _hearthstoneCardCache.Query(new SearchCardsQuery(query));
		}

		[Test]
		public void ShouldReturnExpectedSearchResults()
		{
            // -1 becuase there is one hero card - task 2c
			_result.Count().ShouldEqual(Cards().Count()-1);
		}
	}
}