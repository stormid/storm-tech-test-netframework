using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Models;
using System.Collections.Generic;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {
        private string _defaultOption = "Select PlayerClass";
        private List<SelectListItem> _listOfPlayerClasses;

        public ActionResult Index(string q = null, string PlayerClasses = null)
		{
            var searchService = new CardSearchService(MvcApplication.CardCache);

            //get PlayerClasses
            if (_listOfPlayerClasses == null || _listOfPlayerClasses.Count() < 1)
            {
                var cards = searchService.Search(null);
                _listOfPlayerClasses = cards.Select(x => x.PlayerClassText).Distinct().ToList().Select(o => new SelectListItem { Value = o, Text = o }).OrderBy(x => x.Text).ToList();
            }

            //add PlayerClass selection
            if (!string.IsNullOrWhiteSpace(PlayerClasses) && PlayerClasses != _defaultOption)
            {
                _listOfPlayerClasses.Where(x => x.Value == PlayerClasses).Single().Selected = true;
            }

            CardsVm viewModel = new CardsVm();           
           
            //search by keyword
			viewModel.Cards = searchService.Search(q);

            //filter by PlayerClass
            if (!string.IsNullOrWhiteSpace(PlayerClasses) && PlayerClasses != _defaultOption)
            {
                viewModel.Cards = viewModel.Cards.Where(x => x.PlayerClassText == PlayerClasses);
            }

            viewModel.PlayerClasses = _listOfPlayerClasses;
            viewModel.SearchedKeyword = !string.IsNullOrWhiteSpace(q) ? q : "";

			return View(viewModel);
		}
	}
}