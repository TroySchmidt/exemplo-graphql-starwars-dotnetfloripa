using AutoMapper;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Api.Profiles
{
    public class DroidProfile : Profile
    {
        public DroidProfile()
        {
            CreateMap<Droid, GraphQL.ViewModels.Droid>(MemberList.Destination)
                .IncludeBase<Character, GraphQL.ViewModels.Character>();
        }
    }
}