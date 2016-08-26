using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base
{
	public abstract class CardListLinqQueryObject<T> : CardListQueryObject<T> where T : ICard
	{
		public override IEnumerable<T> Execute(IHearthstoneCardRepository repository)
		{
			return ExecuteLinq(repository.FindAll<T>().AsQueryable());
		}

		protected abstract IEnumerable<T> ExecuteLinq(IQueryable<T> queryOver);
	}
}