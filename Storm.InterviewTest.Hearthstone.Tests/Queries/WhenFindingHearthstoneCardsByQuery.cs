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
	public class WhenFindingHearthstoneCardsByQuery : HearthstoneCardCacheContext
	{
		protected IEnumerable<ICard> _result;

		protected override void Because()
		{
			_result = _hearthstoneCardRepository.Query(new FindAllCardsQuery());
		}

		[Test]
		public void ShouldReturnExpectedSearchResults()
		{
			_result.Count().ShouldEqual(Cards().Count());
		}
	}
}