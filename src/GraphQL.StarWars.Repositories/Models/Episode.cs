using System.Collections.Generic;
using GraphQL.StarWars.Repositories.Abstractions;

namespace GraphQL.StarWars.Repositories.Models
{
    public class Episode : IEntity<int>
    {
        public string Title { get; set; }
        public Character Hero { get; set; }
        public ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
        public int Id { get; set; }
    }
}