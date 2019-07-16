using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Repositories
{
    public class PlanetRepository : Repository<Planet, int>, IPlanetRepository
    {
        public PlanetRepository(StarWarsContext dbContext) : base(dbContext)
        {
        }
    }
}