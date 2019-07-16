using AutoMapper;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Api.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, GraphQL.ViewModels.Character>(MemberList.Destination)
                .ForMember(dest => dest.Friends, opt => opt.Ignore())
                .ForMember(dest => dest.AppearsIn, opt => opt.Ignore()
                );
        }
    }
}