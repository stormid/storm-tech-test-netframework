using Storm.InterviewTest.Hearthstone.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    /// <summary>
    /// This tests PlayerClass search case sensitivity, if fix not applied then it should fail.
    /// Task 2a
    /// </summary>
    public class WhenSearchingHearthstoneCardsWithPlayerClassCapitalLetter : HearthstoneCardCacheContext
    {
        protected IEnumerable<ICard> _result;
        protected string query;

        protected override IEnumerable<ICard> Cards()
        {
            return new List<ICard>()
            {
                CreateRandomMinionCardWithId("01", minion =>
                {
                    minion.PlayerClass = "Mage";
                })
            };
        }

        protected override void Context()
        {
            query = "mage";
        }

        protected override void Because()
        {
            _result = _hearthstoneCardCache.Query(new SearchCardsQuery(query));
        }

        [Test]
        public void ShouldFindOneCard()
        {
            Assert.AreEqual(_result.Count(), 1);
            Assert.AreEqual(_result.ToList()[0].PlayerClass, "Mage");
        }
    }
}
