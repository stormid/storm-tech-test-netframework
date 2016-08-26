using AutoMapper;
using FizzWare.NBuilder.Dates;
using Moq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Mapping;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
	[Category("Mapping")]
	public abstract class MappingCardsContext : ContextSpecification
	{
		protected HeroCard _heroCard;
		protected Mock<IHearthstoneCardRepository> _repository;
	    protected IMapper _mapper;


		protected override void SharedContext()
		{
			_heroCard = new HeroCard("H1")
			{
				Name = "My Hero",
                PlayerClass = null
			};

 			_repository = CreateDependency<IHearthstoneCardRepository>();

            // Mock our repo to only return hero card whenever player class is not null
			_repository.Setup(s => s.Query(It.Is<FindHeroCardQuery>(y => y != null))).Returns(_heroCard);

           _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CardsMappingProfile>();

            }).CreateMapper(t =>
            {
                // Poor man's dependency injection
                if(t == typeof(HeroResolver))
                    return new HeroResolver(_repository.Object);

                return null;
            });



		}
	}
}
