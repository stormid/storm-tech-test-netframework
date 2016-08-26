using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
	public interface IHearthstoneCardRepository
	{
		TCard GetById<TCard>(string id) where TCard : ICard;
		IEnumerable<TCard> FindAll<TCard>() where TCard : ICard;
		IEnumerable<TCard> Query<TCard>(CardListQueryObject<TCard> query) where TCard : ICard;
		TCard Query<TCard>(SingleCardQueryObject<TCard> query) where TCard : ICard;
	}
}