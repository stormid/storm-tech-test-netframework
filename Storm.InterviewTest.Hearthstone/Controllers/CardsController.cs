using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.Internal;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {
		public ActionResult Index(string q = null, string playerClass = null)
		{
			var searchService = new CardSearchService(MvcApplication.CardCache);
			var cards = searchService.Search(q, playerClass);

		    var viewModel = new CardsSearchViewModel
		    {
                SearchTerm = q,
		        Cards = cards,
		        PlayerClasses = searchService.Search(null).Select(x => x.PlayerClassText.ToString()).Distinct()
		    };

			return View(viewModel);
		}
	}
}