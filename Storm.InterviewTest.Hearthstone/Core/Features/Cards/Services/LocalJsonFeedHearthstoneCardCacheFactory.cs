using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using System.Linq;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class LocalJsonFeedHearthstoneCardCacheFactory : HearthstoneCardCacheFactory
	{
        private string _cardsSource;
        private string _cardTypes;

		public LocalJsonFeedHearthstoneCardCacheFactory(IHearthstoneCardParser parser, string cardsSource, string cardTypes) : base(parser)
		{
            _cardsSource = cardsSource;
            _cardTypes = cardTypes;
		}

        //task 5
		protected override IEnumerable<ICard> PopulateCards(IHearthstoneCardParser parser)
		{
            var types = _cardTypes.Split(',');

            List<ICard> result = new List<ICard>();

            JObject cardSets;

            using (var reader = File.OpenText(HttpContext.Current.Server.MapPath(_cardsSource)))
            {
                cardSets = JObject.Parse(reader.ReadToEnd());           
            }

            foreach (var child in cardSets)
            {
               if (types.Contains(child.Key.ToString()))
               {
                  result.AddRange(parser.ParseArray(child.Value.ToString()));
               }
            }

            result = result.Where(x => x != null).ToList();		

            return result;
		}
	}
}