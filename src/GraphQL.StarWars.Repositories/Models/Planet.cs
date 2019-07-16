using System.Collections.Generic;
using GraphQL.StarWars.Repositories.Abstractions;

namespace GraphQL.StarWars.Repositories.Models
{
    public class Planet : IEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Human> Humans { get; set; }
        public int Id { get; set; }
    }
}