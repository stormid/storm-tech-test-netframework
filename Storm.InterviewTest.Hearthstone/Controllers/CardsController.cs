using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardSearchService _cardSearchService;

        public CardsController(ICardSearchService cardSearchService)
        {
            _cardSearchService = cardSearchService;
        }

        public ActionResult Index(string q = null)
		{
			var cards = _cardSearchService.Search(q);

			return View(cards);
		}
	}
}