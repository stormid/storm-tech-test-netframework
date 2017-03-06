using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class CardsVm
    {
        public IEnumerable<CardModel> Cards { get; set; }

        public List<SelectListItem> PlayerClasses { get; set; }

        public string SearchedKeyword { get; set; }
    }
}