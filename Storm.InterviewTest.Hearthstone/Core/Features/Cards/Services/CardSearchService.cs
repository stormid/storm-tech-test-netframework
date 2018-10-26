using System.Collections.Generic;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class CardSearchService : ICardSearchService
	{
		private readonly IHearthstoneCardRepository _cardRepository;
	    private readonly IMapper _mapper;

	    public CardSearchService(IHearthstoneCardRepository cardRepository, IMapper mapper)
	    {
	        _cardRepository = cardRepository;
	        _mapper = mapper;
	    }

	    public CardModel FindById(string id)
		{
			var card = _cardRepository.GetById<ICard>(id);
			return _mapper.Map<ICard, CardModel>(card);
		}

		public IEnumerable<CardModel> Search(string searchTerm)
		{
			var cards = _cardRepository.Query(new SearchCardsQuery(searchTerm));
		    foreach (var card in cards)
		    {
		        var temp = _mapper.Map<ICard, CardModel>(card);
		    }
			return _mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(cards);
		}

		public IEnumerable<CardModel> GetHeroes()
		{
			var heroes = _cardRepository.Query(new FindPlayableHeroCardsQuery());
			return _mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(heroes);
		}
	}
}
