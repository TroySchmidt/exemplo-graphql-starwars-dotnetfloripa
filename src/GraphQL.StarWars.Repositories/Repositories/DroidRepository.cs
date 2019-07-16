using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Repositories
{
    public class DroidRepository : Repository<Droid, int>, IDroidRepository
    {
        public DroidRepository(StarWarsContext dbContext) : base(dbContext)
        {
        }
    }
}