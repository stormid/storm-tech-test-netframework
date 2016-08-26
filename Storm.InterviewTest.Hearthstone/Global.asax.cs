using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone
{
	public class MvcApplication : HttpApplication
	{
		public static IHearthstoneCardCache CardCache { get; private set; }

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyInjection.RegisterServices();

			CardCache = CardCacheConfig.BuildCardCache();

			AutoMapperProfiles.RegisterProfiles(CardCache);
		}
	}
}
