using System;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Mapping
{
	public class CardsMappingProfile : Profile
	{
		protected override void Configure()
		{

			CreateMap<ICard, CardModel>()
                .ForMember(x => x.PlayerClass, opt => opt.ResolveUsing<HeroResolver>())
                .ForMember(m => m.PlayerClassText, opt =>
                {
                    opt.NullSubstitute("Neutral");
                    opt.MapFrom(m => m.PlayerClass);
                })
                .Include<Card,CardModel>();
            

		    CreateMap<Card, CardModel>()
                .Include<MinionCard, MinionModel>()
                .Include<WeaponCard, WeaponModel>()
                .Include<SpellCard, SpellModel>();

		    CreateMap<MinionCard, MinionModel>()
                .Include<HeroCard, HeroModel>();

		    CreateMap<WeaponCard, WeaponModel>();

		    CreateMap<SpellCard, SpellModel>();

            CreateMap<HeroCard, HeroModel>()
                .ForMember(x => x.PlayerClass, opt => opt.Ignore()); 


        }
	}

    public class HeroResolver : IValueResolver<ICard, CardModel, HeroModel>
    {
        private readonly IHearthstoneCardRepository _repository;

        public HeroResolver(IHearthstoneCardRepository repository)
        {
            _repository = repository;
        }

        public HeroModel Resolve(ICard source, CardModel destination, HeroModel destMember, ResolutionContext context)
        {
            if (String.IsNullOrEmpty(source.PlayerClass))
                return null;

            var heroCard =  _repository.Query(new FindHeroCardQuery(source.PlayerClass));

            
            return heroCard == null ? null : context.Mapper.Map<HeroCard, HeroModel>(heroCard);
        }
    }
}