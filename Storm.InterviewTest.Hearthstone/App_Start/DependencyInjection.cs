using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Storm.InterviewTest.Hearthstone
{
    public class DependencyInjection
    {
        public static void RegisterServices()
        {
            var builder = new ContainerBuilder();

            // Register MVC Controllers
            builder.RegisterControllers(typeof (MvcApplication).Assembly);

            // Register abstractions
            builder.RegisterModule<AutofacWebTypesModule>();

            // Enable property injection for action filters (although we aren't using them yet)
            builder.RegisterFilterProvider();

            // Explicitly register services we require




            // Set container to Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}