using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Tests.Base;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
	[Category("Cache")]
	public class WhenFindingSpecificCardTypeByIdHearthstoneCards : HearthstoneCardCacheContext
	{
		protected ICard _result;

		protected override void Because()
		{
			_result = _hearthstoneCardRepository.GetById<MinionCard>("M1");
		}

		[Test]
		public void ShouldReturnExpectedCard()
		{
			_result.Id.ShouldEqual("M1");
		}
	}
}