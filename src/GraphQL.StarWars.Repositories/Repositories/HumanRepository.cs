using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Repositories
{
    public class HumanRepository : Repository<Human, int>, IHumanRepository
    {
        public HumanRepository(StarWarsContext dbContext) : base(dbContext)
        {
        }
    }
}