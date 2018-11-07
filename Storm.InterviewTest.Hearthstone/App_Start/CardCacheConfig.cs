using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System.Configuration;

namespace Storm.InterviewTest.Hearthstone
{
	public class CardCacheConfig
	{
		public static IHearthstoneCardCache BuildCardCache()
		{
            //task 5
            var cardsSource = ConfigurationManager.AppSettings["CardSource"];
            var cardTypes = ConfigurationManager.AppSettings["CardTypesToCache"];
            var parser = new HearthstoneCardParser();
			var factory = new LocalJsonFeedHearthstoneCardCacheFactory(parser, cardsSource, cardTypes);           

            return factory.Create();
		}
	}
}