using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Abstractions
{
    public interface ICharacterRepository : IRepository<Character, int>
    {
        Task<ICollection<Character>> GetFriendsAsync(int id);
        Task<ICollection<Episode>> GetEpisodesAsync(int id);
    }
}