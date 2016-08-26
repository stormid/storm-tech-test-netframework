using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autofac;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Mapping;

namespace Storm.InterviewTest.Hearthstone.Core.DependencyInjection
{
    public class AutomapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register our profiles explicitly
            builder.RegisterType<CardsMappingProfile>().As<Profile>();


            // based on http://kevsoft.net/2016/02/24/automapper-and-autofac-revisited.html

            builder.Register(context =>
            {
                var profiles = context.Resolve<IEnumerable<Profile>>();

                var config = new MapperConfiguration(x =>
                {
                    // Load in all our AutoMapper profiles that have been registered
                    foreach (var profile in profiles)
                    {
                        x.AddProfile(profile);
                    }
                });
                Debug.WriteLine("{0} mappers loaded", config.GetMappers().Count());
                return config;
            }).SingleInstance()  // We only need one instance
              .AutoActivate()    // Create it on ContainerBuilder.Build()
              .AsSelf();         // Bind it to its own type


            builder.Register(context =>
            {
                var ctx = context.Resolve<IComponentContext>();
                var config = ctx.Resolve<MapperConfiguration>();

                Debug.WriteLine("{0} mappers loaded", config.GetMappers().Count());
                // Create our mapper using our configuration above
                return config.CreateMapper(t => ctx.Resolve(t));

            }).As<IMapper>()
              .InstancePerLifetimeScope(); // Bind it to the IMapper interface

            base.Load(builder);
        }

    
    }
}