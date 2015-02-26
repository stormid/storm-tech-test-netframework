using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Core.Features.DeckBuilder.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
	public class MyDecksController : Controller
	{
		public ActionResult Index()
		{
		    var deckBuilderService = new DeckBuilderService(MvcApplication.CardCache);
		    var decks = deckBuilderService.GetAllDecks();
		    var a = decks;

		    deckBuilderService.CreateDeck("My First Deck", "HERO_01");
            
            var searchService = new CardSearchService(MvcApplication.CardCache);
			var heroes = searchService.GetHeroes();
			return View(heroes);
		}
	}
}