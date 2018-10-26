using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public abstract class HearthstoneCardCacheFactory : IHearthstoneCardCacheFactory
	{
		private readonly IHearthstoneCardParser _parser;

		protected HearthstoneCardCacheFactory(IHearthstoneCardParser parser)
		{
			_parser = parser;
		}

		public IHearthstoneCardRepository Create()
		{
			var cards = PopulateCards(_parser);
			return new HearthstoneCardRepository(cards.ToList());
		}

		protected abstract IEnumerable<ICard> PopulateCards(IHearthstoneCardParser parser);
	}
}