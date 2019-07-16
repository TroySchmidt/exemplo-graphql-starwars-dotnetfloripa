using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Abstractions
{
    public interface IPlanetRepository : IRepository<Planet, int>
    {
    }
}