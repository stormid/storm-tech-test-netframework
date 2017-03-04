using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
	public interface ICardSearchService
	{
		CardModel FindById(string id);
		IEnumerable<CardModel> Search(string searchTerm, string playerClass = null);
		IEnumerable<CardModel> GetHeroes();
	}
}