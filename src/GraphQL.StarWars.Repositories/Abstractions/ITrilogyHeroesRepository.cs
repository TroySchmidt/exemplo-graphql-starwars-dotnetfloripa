using System.Threading.Tasks;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Abstractions
{
    public interface ITrilogyHeroesRepository
    {
        Task<Character> GetHero(int? episodeId);
    }
}