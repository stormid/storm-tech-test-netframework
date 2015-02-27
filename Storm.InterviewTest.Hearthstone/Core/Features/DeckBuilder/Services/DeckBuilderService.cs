using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using AutoMapper;
using Newtonsoft.Json;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Services
{
    public class DeckBuilderService : IDeckBuilderService
    {
        private readonly IHearthstoneCardCache _cardCache;
        private readonly IList<Deck> _decks;
        private readonly string _decksFilePath;

		public DeckBuilderService(IHearthstoneCardCache cardCache)
		{
			_cardCache = cardCache;
            _decks = new List<Deck>();
		    _decksFilePath = HttpContext.Current.Server.MapPath("~/App_Data/decks.json");

		    if (File.Exists(_decksFilePath))
		    {
		        SaveDecks();
		    }

		    _decks = JsonConvert.DeserializeObject<IList<Deck>>(File.ReadAllText(_decksFilePath));
        }

        public IEnumerable<DeckModel> GetAllDecks()
        {
            return _decks.Select(BuildDeckModel);
        }

        public DeckModel GetDeck(string name)
        {
            var deck = _decks.FirstOrDefault(x => x.Name == name);
            if (deck == null)
            {
                return null;
            }

            return BuildDeckModel(deck);
        }

        public DeckModel CreateDeck(string name, string heroId, IEnumerable<string> cardIds)
        {
            var deck = new Deck()
            {
                Name = name
            };

            var heroCard = _cardCache.GetById<ICard>(heroId);
            deck.HeroCardId = heroId;
            deck.PlayerClass = heroCard.PlayerClass;

            foreach (var cardId in cardIds)
            {
                deck.AddCard(_cardCache.GetById<ICard>(cardId));
            }

            if (deck.CardIds.Count() != 30)
            {
                return null;
            }

            _decks.Add(deck);
            SaveDecks();

            return BuildDeckModel(deck);
        }

        private void SaveDecks()
        {
            var json = JsonConvert.SerializeObject(_decks);
            File.WriteAllText(_decksFilePath, json);
        }

        private DeckModel BuildDeckModel(Deck deck)
        {
            var deckModel = new DeckModel
            {
                Name = deck.Name,
                HeroModel = Mapper.Map<CardModel>(_cardCache.GetById<ICard>(deck.HeroCardId))
            };

            var cards = deck.CardIds.Select(cardId => Mapper.Map<CardModel>(_cardCache.GetById<ICard>(cardId))).ToList();
            deckModel.Cards = cards;

            return deckModel;
        }
    }
}