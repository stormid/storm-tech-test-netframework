using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone
{
	public class CardCacheConfig
	{
		public static IHearthstoneCardRepository BuildCardCache()
		{
			var parser = new HearthstoneCardParser();
			var factory = new LocalJsonFeedHearthstoneCardCacheFactory(parser);
			return factory.Create();
		}
	}
}