using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base
{
    public abstract class CardListQueryObject<T> where T : ICard
    {
        public abstract IEnumerable<T> Execute(IHearthstoneCardRepository repository);
    }
}