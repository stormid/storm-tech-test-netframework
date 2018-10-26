namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
	public interface IHearthstoneCardCacheFactory
	{
		IHearthstoneCardRepository Create();
	}
}