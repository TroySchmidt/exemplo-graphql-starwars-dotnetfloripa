using AutoMapper;
using GraphQL.StarWars.Api.GraphQL.Types;
using GraphQL.StarWars.Api.GraphQL.ViewModels;
using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.Types;

namespace GraphQL.StarWars.Api.GraphQL
{
    public class StarWarsQuery : ObjectGraphType<object>
    {
        public StarWarsQuery(ITrilogyHeroesRepository trilogyHeroesRepository, IDroidRepository droidRepository,
            IHumanRepository humanRepository, IMapper mapper)
        {
            Name = "Query";

            FieldAsync<CharacterInterface>(
                "hero",
                arguments: new QueryArguments(
                    new QueryArgument<EpisodeEnum>
                    {
                        Name = "episode",
                        Description =
                            "If omitted, returns the hero of the whole saga. If provided, returns the hero of that particular episode."
                    }
                ),
                resolve: async context =>
                {
                    var episode = context.GetArgument<Episodes?>("episode");
                    var character = await trilogyHeroesRepository.GetHero((int?) episode);
                    var hero = mapper.Map<Character>(character);
                    return hero;
                }
            );

            FieldAsync<HumanType>(
                "human",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "id", Description = "id of the human"}
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var human = await humanRepository.GetAsync(id, "HomePlanet");
                    var mapped = mapper.Map<Human>(human);
                    return mapped;
                }
            );
            FieldAsync<DroidType>(
                "droid",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "id", Description = "id of the droid"}
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var droid = await droidRepository.GetAsync(id);
                    var mapped = mapper.Map<Droid>(droid);
                    return mapped;
                }
            );
        }
    }
}