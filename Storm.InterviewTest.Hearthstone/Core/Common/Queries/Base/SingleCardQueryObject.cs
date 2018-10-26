using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base
{
	public abstract class SingleCardQueryObject<T> where T : ICard
	{
		public abstract T Execute(IHearthstoneCardRepository repository);
	}
}