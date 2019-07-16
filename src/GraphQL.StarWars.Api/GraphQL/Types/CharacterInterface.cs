using GraphQL.StarWars.Api.GraphQL.ViewModels;
using GraphQL.StarWars.Api.Properties;
using GraphQL.Types;

namespace GraphQL.StarWars.Api.GraphQL.Types
{
    public class CharacterInterface : InterfaceGraphType<Character>
    {
        public CharacterInterface()
        {
            Name = nameof(Character);

            Field(d => d.Id).Description(string.Format(Descriptions.The_id_of_the_0, Name));
            Field(d => d.Name, true).Description(string.Format(Descriptions.The_name_of_the_0, Name));

            Field<ListGraphType<CharacterInterface>>(FieldNames.Friends);
            Field<ListGraphType<EpisodeEnum>>(FieldNames.Appearsin, Descriptions.Which_movie_they_appear_in);
        }
    }
}