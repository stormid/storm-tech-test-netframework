using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
		private readonly string _q;

		public SearchCardsQuery(string q)
		{
			_q = q ?? string.Empty;
		}

        protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
            // do not include hero cards in search - task 2c
            // fixed case sensitivity search for PlayerClass - task 2a
            var result = queryOver.Where(x => x.Type != CardTypeOptions.Hero
            && x.Name.Contains(_q)
            || x.Type.ToString() == _q
            || string.Equals(x.PlayerClass, _q, StringComparison.OrdinalIgnoreCase));

            return result;
		}
	}
}