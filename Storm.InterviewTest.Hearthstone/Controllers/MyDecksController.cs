using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
	public class MyDecksController : Controller
	{
	    private readonly ICardSearchService _cardSearchService;

	    public MyDecksController(ICardSearchService cardSearchService)
	    {
	        _cardSearchService = cardSearchService;
	    }

	    public ActionResult Index()
		{
			var heroes = _cardSearchService.GetHeroes();
			return View(heroes);
		}
	}
}