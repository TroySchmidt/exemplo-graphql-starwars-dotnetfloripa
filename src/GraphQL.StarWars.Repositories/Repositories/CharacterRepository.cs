using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Repositories
{
    public class CharacterRepository : Repository<Character, int>, ICharacterRepository
    {
        public CharacterRepository(StarWarsContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Character>> GetFriendsAsync(int id)
        {
            // TODO: find better way to do this?
            var character = await GetAsync(id, "CharacterFriends.Friend");
            return character.CharacterFriends.Select(c => c.Friend).ToList();
        }

        public async Task<ICollection<Episode>> GetEpisodesAsync(int id)
        {
            // TODO: find better way to do this?
            var character = await GetAsync(id, "CharacterEpisodes.Episode");
            return character.CharacterEpisodes.Select(c => c.Episode).ToList();
        }
    }
}