using AutoMapper;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Api.Profiles
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<Human, GraphQL.ViewModels.Human>(MemberList.Destination)
                .IncludeBase<Character, GraphQL.ViewModels.Character>()
                .ForMember(
                    dest => dest.HomePlanet,
                    opt => opt.MapFrom(src => src.HomePlanet.Name)
                );
            
            CreateMap<GraphQL.ViewModels.Human, Human>(MemberList.Destination)
                .ForMember(
                    dest => dest.HomePlanet,
                    opt => opt.Ignore()
                );
        }
    }
}