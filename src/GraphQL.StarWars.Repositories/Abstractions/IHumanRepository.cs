using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Abstractions
{
    public interface IHumanRepository : IRepository<Human, int>
    {
    }
}