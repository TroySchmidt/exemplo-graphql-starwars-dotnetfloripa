using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL.StarWars.Api.GraphQL.ViewModels;
using GraphQL.StarWars.Api.Properties;
using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.Types;

namespace GraphQL.StarWars.Api.GraphQL.Types
{
    public class HumanType : ObjectGraphType<Human>
    {
        public HumanType(ICharacterRepository characterRepository, IMapper mapper)
        {
            Name = nameof(Human);

            Field(h => h.Id).Description(string.Format(Descriptions.The_id_of_the_0, Name));
            Field(h => h.Name, true).Description(string.Format(Descriptions.The_name_of_the_0, Name));

            FieldAsync<ListGraphType<CharacterInterface>>(
                FieldNames.Friends, 
                resolve: async context =>
                {
                    var friends = await characterRepository.GetFriendsAsync(int.Parse(context.Source.Id));
                    var mapped = mapper.Map<IEnumerable<Character>>(friends);
                    return mapped;
                }
            );

            FieldAsync<ListGraphType<EpisodeEnum>>(
                FieldNames.Appearsin,
                Descriptions.Which_movie_they_appear_in,
                resolve: async context =>
                {
                    var episodes = await characterRepository.GetEpisodesAsync(int.Parse(context.Source.Id));
                    var episodeEnums = episodes.Select(y => (Episodes) y.Id).ToArray();
                    return episodeEnums;
                }
            );

            Field(h => h.HomePlanet, true).Description(Descriptions.The_home_planet_of_the_human);

            Interface<CharacterInterface>();
        }
    }
}