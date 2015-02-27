using System.Collections.Generic;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder;
using Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Services;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
	public class MyDecksController : Controller
	{
        IDeckBuilderService DeckBuilderService { get; set; }
        ICardSearchService CardSearchService { get; set; }

	    public MyDecksController()
	    {
            DeckBuilderService = new DeckBuilderService(MvcApplication.CardCache);
            CardSearchService = new CardSearchService(MvcApplication.CardCache);
	    }

		public ActionResult Index()
		{
		    var viewModel = new DeckBuilderBrowseViewModel
		    {
		        Decks = DeckBuilderService.GetAllDecks(),
		        Heroes = CardSearchService.GetHeroes()
		    };

			return View(viewModel);
		}

	    public ActionResult Create(string id)
	    {
	        var hero = CardSearchService.FindById(id);
	        if (hero.Type != CardTypeOptions.Hero.ToString())
	        {
	            return RedirectToAction("Index");
	        }

	        var availableCards = new List<CardModel>();
            availableCards.AddRange(CardSearchService.Search("", hero.PlayerClassText));
            availableCards.AddRange(CardSearchService.Search(""));

	        var viewModel = new DeckBuilderCreateViewModel
	        {
	            HeroCard = hero,
	            AvailableCards = availableCards
	        };

	        return View(viewModel);
	    }

	    [HttpPost]
	    public ActionResult Create(string id, string name, string[] cardIds)
	    {
	        var deck = DeckBuilderService.CreateDeck(name, id, cardIds);
	        if (deck == null)
	        {
	            ModelState.AddModelError("", "Deck could not be created, please try again.");
                return RedirectToAction("Create", new { id });
	        }

            return RedirectToAction("ViewDeck", new { name = deck.Name });
	    }

	    public ActionResult ViewDeck(string name)
	    {
	        var deck = DeckBuilderService.GetDeck(name);
	        if (deck == null)
	        {
	            return RedirectToAction("Index");
	        }

            return View();
	    }
	}
}