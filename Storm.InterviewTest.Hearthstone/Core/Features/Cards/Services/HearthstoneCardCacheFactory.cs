using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public abstract class HearthstoneCardCacheFactory : IHearthstoneCardCacheFactory
	{
		protected readonly IHearthstoneCardParser _parser;

		protected HearthstoneCardCacheFactory(IHearthstoneCardParser parser)
		{
			_parser = parser;
		}

		public IHearthstoneCardCache Create()
		{
			var cards = PopulateCards();
			return new HearthstoneCardCache(cards.ToList());
		}

		protected abstract IEnumerable<ICard> PopulateCards();
	}
}