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
		    _q = _q.ToLowerInvariant();
		}

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
			return queryOver.Where(x => x.Name.ToLowerInvariant().Contains(_q) || x.Type.ToString().ToLowerInvariant() == _q || (x.PlayerClass != null && x.PlayerClass.ToLowerInvariant() == _q));
		}
	}
}