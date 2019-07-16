using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Abstractions
{
    public interface IEpisodeRepository : IRepository<Episode, int>
    {
    }
}