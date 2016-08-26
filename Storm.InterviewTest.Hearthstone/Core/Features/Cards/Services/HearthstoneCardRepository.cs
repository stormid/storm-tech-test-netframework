using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class HearthstoneCardRepository : IHearthstoneCardRepository
	{
		private readonly IEnumerable<ICard> _cards;

		public HearthstoneCardRepository(IEnumerable<ICard> cards)
		{
			_cards = cards;
		}

		public TCard GetById<TCard>(string id) where TCard : ICard
		{
			return _cards.OfType<TCard>().FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<TCard> FindAll<TCard>() where TCard : ICard
		{
			return _cards.OfType<TCard>();
		}

		public IEnumerable<TCard> Query<TCard>(CardListQueryObject<TCard> query) where TCard : ICard
		{
			var result = query.Execute(this);
			return result.ToList();
		}

		public TCard Query<TCard>(SingleCardQueryObject<TCard> query) where TCard : ICard
		{
			return query.Execute(this);
		}
	}
}