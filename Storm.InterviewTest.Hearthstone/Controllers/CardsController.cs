using System.Linq;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {
		public ActionResult Index(string q = null, string playerClass = null, int page = 1)
		{
		    const int cardsPerPage = 25;

			var searchService = new CardSearchService(MvcApplication.CardCache);
			var cards = searchService.Search(q, playerClass).ToList();
		    var totalCards = cards.Count;

		    var viewModel = new CardsSearchViewModel
		    {
                SearchTerm = q,
                PlayerClass = playerClass,
		        Cards = cards.Skip(cardsPerPage * (page - 1)).Take(cardsPerPage),
		        PlayerClasses = searchService.Search(null).Select(x => x.PlayerClassText.ToString()).Distinct(),
                CurrentPage = page,
                TotalPages = totalCards == 0 ? 1 : ((totalCards-1) / cardsPerPage) + 1,
                TotalCards = totalCards
		    };

			return View(viewModel);
		}
	}
}