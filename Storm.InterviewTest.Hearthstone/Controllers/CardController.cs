using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
	public class CardController : Controller
	{
	    private readonly ICardSearchService _cardSearchService;

	    public CardController(ICardSearchService cardSearchService)
	    {
	        _cardSearchService = cardSearchService;
	    }

	    public ActionResult Details(string id)
		{

			var model = _cardSearchService.FindById(id);

			return View(model);
		}
	}
}