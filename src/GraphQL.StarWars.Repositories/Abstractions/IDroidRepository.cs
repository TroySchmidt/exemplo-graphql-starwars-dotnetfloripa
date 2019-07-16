using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Abstractions
{
    public interface IDroidRepository : IRepository<Droid, int>
    {
    }
}