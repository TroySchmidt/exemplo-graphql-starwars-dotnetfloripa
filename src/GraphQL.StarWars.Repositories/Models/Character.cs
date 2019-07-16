using System.Collections.Generic;
using GraphQL.StarWars.Repositories.Abstractions;

namespace GraphQL.StarWars.Repositories.Models
{
    public class Character : IEntity<int>
    {
        public string Name { get; set; }
        public ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
        public ICollection<CharacterFriend> CharacterFriends { get; set; }
        public ICollection<CharacterFriend> FriendCharacters { get; set; }
        public int Id { get; set; }
    }
}