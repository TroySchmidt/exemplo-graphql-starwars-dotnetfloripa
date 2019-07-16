using System.Threading.Tasks;
using GraphQL.StarWars.Repositories.Abstractions;
using GraphQL.StarWars.Repositories.Models;

namespace GraphQL.StarWars.Repositories.Repositories
{
    public class TrilogyHeroesRepository : ITrilogyHeroesRepository
    {
        private readonly IDroidRepository _droidRepository;
        private readonly IEpisodeRepository _episodeRepository;

        public TrilogyHeroesRepository(IEpisodeRepository episodeRepository, IDroidRepository droidRepository)
        {
            _episodeRepository = episodeRepository;
            _droidRepository = droidRepository;
        }

        public async Task<Character> GetHero(int? episodeId)
        {
            const int r2d2Id = 2001;

            if (episodeId.HasValue)
            {
                var episode = await _episodeRepository.GetAsync(episodeId.Value, "Hero");
                return episode.Hero;
            }

            var r2d2 = await _droidRepository.GetAsync(r2d2Id);

            return r2d2;
        }
    }
}