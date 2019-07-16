using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Repositories
{
    public class EpisodeRepository : Repository<Episode, int>, IEpisodeRepository
    {
        public EpisodeRepository(StarWarsContext dbContext) : base(dbContext)
        {
        }
    }
}