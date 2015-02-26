using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class LocalJsonFeedHearthstoneCardCacheFactory : HearthstoneCardCacheFactory
	{
	    private JObject _cardSets;

		public LocalJsonFeedHearthstoneCardCacheFactory(IHearthstoneCardParser parser) : base(parser)
		{
		}

		protected override IEnumerable<ICard> PopulateCards()
		{
		    using (var reader = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/cards.json")))
		    {
		        _cardSets = JObject.Parse(reader.ReadToEnd());
		    }

		    var cards = new List<ICard>();
		    cards.AddRange(GetCardSet("Basic"));
            cards.AddRange(GetCardSet("Classic"));
		    cards.AddRange(GetCardSet("Curse of Naxxramas"));
		    cards.AddRange(GetCardSet("Goblins vs Gnomes"));

		    return cards;
		}

	    public IEnumerable<ICard> GetCardSet(string name)
        {
            JToken cards;
            if (_cardSets.TryGetValue(name, out cards) && cards.Type == JTokenType.Array)
            {
                foreach (var card in cards)
                {
                    var parsedCard = _parser.Parse(card.ToString());
                    if (parsedCard != null)
                    {
                        yield return parsedCard;
                    }
                }
            }
	    }
	}
}