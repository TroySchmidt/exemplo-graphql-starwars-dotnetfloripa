namespace GraphQL.StarWars.Repositories.Abstractions
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}