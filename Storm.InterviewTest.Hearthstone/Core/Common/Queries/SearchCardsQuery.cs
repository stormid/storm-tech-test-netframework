using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
		private readonly string _q;
	    private readonly string _playerClass;

		public SearchCardsQuery(string q, string playerClass = null)
		{
			_q = q ?? string.Empty;
		    _q = _q.ToLowerInvariant();
		    _playerClass = playerClass ?? string.Empty;
		    _playerClass = _playerClass.ToLowerInvariant();
		}

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
            var results = queryOver.Where(x => x.Name.ToLowerInvariant().Contains(_q) ||
		                                    x.Type.ToString().ToLowerInvariant() == _q ||
		                                    (x.PlayerClass != null && x.PlayerClass.ToLowerInvariant() == _q));

		    if (!_playerClass.IsNullOrWhiteSpace())
		    {

		        return _playerClass == "neutral" ? results.Where(x => x.PlayerClass == null) : results.Where(x => x.PlayerClass != null && x.PlayerClass.ToLowerInvariant() == _playerClass);
		    }

		    return results;
		}
	}
}