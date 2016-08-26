using Autofac;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Core.DependencyInjection
{
    public class HearthstoneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // We need some fakery to simulate a database
            
            // register the underlying card cache factory
            // Normally, one per request, but this is read-only

            builder.Register(c => CardCacheConfig.BuildCardCache())
                .As<IHearthstoneCardRepository>()
                .InstancePerLifetimeScope();

            // Now register our other services
            builder.RegisterType<CardSearchService>().As<ICardSearchService>();

            base.Load(builder);
        }
    }
}