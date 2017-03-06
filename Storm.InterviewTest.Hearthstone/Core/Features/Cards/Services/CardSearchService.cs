using System.Collections.Generic;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class CardSearchService : ICardSearchService
	{
		private readonly IHearthstoneCardCache _cardCache;

		public CardSearchService(IHearthstoneCardCache cardCache)
		{
			_cardCache = cardCache;
		}

		public CardModel FindById(string id)
		{
			var card = _cardCache.GetById<ICard>(id);
			return Mapper.Map<ICard, CardModel>(card);
		}

		public IEnumerable<CardModel> Search(string searchTerm)
		{
			var cards = _cardCache.Query(new SearchCardsQuery(searchTerm));
			return Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(cards);
		}

        public IEnumerable<CardModel> GetHeroes()
		{
			var heroes = _cardCache.Query(new FindPlayableHeroCardsQuery());
			return Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(heroes);
		}
	}
}
