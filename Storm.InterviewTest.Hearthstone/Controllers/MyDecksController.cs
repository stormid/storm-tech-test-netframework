using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
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

            if (hero == null || hero.Type != CardTypeOptions.Hero.ToString())
	        {
	            return RedirectToAction("Index");
	        }

	        var viewModel = new DeckBuilderCreateViewModel
	        {
	            HeroCard = hero
	        };

	        if (TempData.ContainsKey("Error"))
	        {
	            ModelState.AddModelError("", TempData["Error"].ToString());
	        }

	        return View(viewModel);
	    }

	    [HttpPost]
	    public ActionResult Create(string id, string name)
	    {
	        var deck = DeckBuilderService.CreateDeck(name, id);
	        if (deck == null)
	        {
	            TempData["Error"] = "Deck could not be created, please try again.";
                return RedirectToAction("Create", new { id });
	        }

            return RedirectToAction("ViewDeck", new { name = deck.Name });
	    }

	    [HttpPost]
	    public JsonResult AddCardToDeck(string name, string cardId)
	    {
	        var deck = DeckBuilderService.GetDeck(name);
            if (deck == null)
            {
                return Json(new DeckBuilderAddCardJsonResult
                {
                    Success = false,
                    ErrorMessage = "Could not find deck"
                }, JsonRequestBehavior.AllowGet);
            }

	        CardModel cardModel;
	        try
            {
	        
                cardModel = DeckBuilderService.AddCardToDeck(name, cardId);
	        }
	        catch (InvalidOperationException e)
	        {
                return Json(new DeckBuilderAddCardJsonResult
                {
                    Success = false,
                    ErrorMessage = e.Message
                }, JsonRequestBehavior.AllowGet);
	        }

	        return Json(new DeckBuilderAddCardJsonResult
	        {
	            Success = true,
                CardId = cardModel.Id,
                CardName = cardModel.Name
	        }, JsonRequestBehavior.AllowGet);
	    }

	    [HttpPost]
	    public JsonResult RemoveCardFromDeck(string name, string cardId)
	    {
            var deck = DeckBuilderService.GetDeck(name);
            if (deck == null)
            {
                return Json(new DeckBuilderAddCardJsonResult
                {
                    Success = false,
                    ErrorMessage = "Could not find deck"
                }, JsonRequestBehavior.AllowGet);
            }

            DeckBuilderService.RemoveCardFromDeck(name, cardId);

            return Json(new DeckBuilderAddCardJsonResult
            {
                Success = true
            }, JsonRequestBehavior.AllowGet);
	    }

	    public ActionResult ViewDeck(string name)
	    {
	        var deck = DeckBuilderService.GetDeck(name);
	        if (deck == null)
	        {
	            return RedirectToAction("Index");
	        }

            var availableCards = new List<CardModel>();
            availableCards.AddRange(CardSearchService.Search("", deck.HeroModel.PlayerClassText));
            availableCards.AddRange(CardSearchService.Search("", "Neutral"));
	        availableCards.RemoveAll(x => x.Type == "Hero");

	        var viewModel = new DeckBuilderEditViewModel
	        {
	            Deck = deck,
	            AvailableCards = availableCards
	        };

            return View(viewModel);
	    }
	}
}