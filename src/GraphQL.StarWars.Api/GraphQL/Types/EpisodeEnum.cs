using GraphQL.StarWars.Api.Properties;
using GraphQL.StarWars.Repositories.Models;
using GraphQL.Types;

namespace GraphQL.StarWars.Api.GraphQL.Types
{
    public class EpisodeEnum : EnumerationGraphType
    {
        public EpisodeEnum()
        {
            Name = nameof(Episode);
            Description = Descriptions.One_of_the_films_in_the_Star_Wars_Trilogy;

            AddValue("NEWHOPE", string.Format(Descriptions.Released_in_0, 1977), 4);
            AddValue("EMPIRE", string.Format(Descriptions.Released_in_0, 1980), 5);
            AddValue("JEDI", string.Format(Descriptions.Released_in_0, 1983), 6);
        }
    }
}